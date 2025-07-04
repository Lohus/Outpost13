using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
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

    public bool AddItem(CraftItem item)
    {
        if (inventory.ContainsKey(item))
        {
            return false;
        }
        else
        {
            inventory.Add(item, 1);
            return true;
        }
    }
    public bool CheckItem(CraftItem item)
    {
        return inventory.ContainsKey(item);
    }
}
