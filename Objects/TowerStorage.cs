using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Tower Storage
public class TowerStorage : MonoBehaviour
{
    [HideInInspector] public static TowerStorage instance; // Singletone
    // Type of resource and amount
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
    // Add resource to storage
    public void AddResource(ResourceItem resource)
    {
        quantityMaterial[resource.resycleRes] += resource.multiplie * PlayerInventory.instance.inventory[resource];
        PlayerInventory.instance.inventory.Remove(resource);
    }
    // Сhecks if there are enough resources to create item
    public bool HashResources(ResourceRequire[] requirements)
    {
        foreach (ResourceRequire require in requirements)
        {
            if (quantityMaterial[require.nameResource] < require.amount)
            {
                return false;
            }
        }
        return true;
    }
    // Take resources from Tower Storage
    public void TakeResources(ResourceRequire[] requirements)
    {
        foreach (ResourceRequire require in requirements)
        {
            quantityMaterial[require.nameResource] -= require.amount;
        }
    }
}