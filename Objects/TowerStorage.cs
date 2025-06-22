using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Outpost Inventory
public class TowerStorage : MonoBehaviour
{
    [HideInInspector] public static TowerStorage instance;
    public Dictionary<string, float> quantityMaterial = new Dictionary<string, float> { { "biomass", 0 }, { "metal", 0 }, { "poly", 0 }, { "iso", 0 } };

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
    public void AddResource(ResourceItem resource)
    {
            quantityMaterial[resource.resycleRes] += resource.multiplie * PlayerInventory.instance.inventory[resource];
            PlayerInventory.instance.inventory.Remove(resource);
    }
}