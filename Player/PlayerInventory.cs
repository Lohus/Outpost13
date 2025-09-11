
using System.Collections.Generic;
using UnityEngine;
// Player inventory
public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance; // Singletone
    public bool tools = false;
    // Inventory
    public Dictionary<Item, int> inventory = new Dictionary<Item, int> { };
    // Clothes
    public Dictionary<TypeClothes, GameObject> clothes = new Dictionary<TypeClothes, GameObject> { };

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Add resource and amount to inventory
    public void AddResourcesToInvetory(ResourceItem resource, int amount)
    {
        if (inventory.ContainsKey(resource))
        {
            inventory[resource] += amount;
        }
        else
        {
            inventory.Add(resource, amount);
        }
    }
    // Add item to inventory
    public bool AddItem(CraftItem item)
    {
        if (inventory.ContainsKey(item))
        {
            return false;
        }
        else
        {
            item.Apply(PlayerController.instance);
            PutCloth(item);
            inventory.Add(item, 1);
            return true;
        }
    }
    // Check if item in inventory
    public bool CheckItem(Item item)
    {
        return inventory.ContainsKey(item);
    }

    // Pun on cloth on player
    public void PutCloth(CraftItem item)
    {
        if (item.typeCloth == null || item.cloth == null) return;
        if (clothes.ContainsKey(item.typeCloth))
        {
            Destroy(clothes[item.typeCloth]);
            clothes[item.typeCloth] = Instantiate(item.cloth, PlayerController.instance.transform);
        }
        else
        {
            clothes.Add(item.typeCloth, Instantiate(item.cloth, PlayerController.instance.transform));
        }
        clothes[item.typeCloth].AddComponent<AttachClothToAvatar>();
    }
}
