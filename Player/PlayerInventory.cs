using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    public Dictionary<ResourceItem, int> inventory = new Dictionary<ResourceItem, int> { };

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
}
