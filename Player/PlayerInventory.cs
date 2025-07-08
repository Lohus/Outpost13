
using System.Collections.Generic;
using UnityEngine;
// Player inventory
public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance; // Singletone
    // Inventory
    public Dictionary<Item, int> inventory = new Dictionary<Item, int> { };

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
            inventory.Add(item, 1);
            return true;
        }
    }
    // Check if item in inventory
    public bool CheckItem(CraftItem item)
    {
        return inventory.ContainsKey(item);
    }
}
