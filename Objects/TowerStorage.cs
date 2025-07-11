using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

// Tower Storage
public class TowerStorage : MonoBehaviour
{
    [HideInInspector] public static TowerStorage instance; // Singletone
    public List<ResourceAmount> storage; // Resource quantity
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
        if (CheckRequireBuilding(resource.buildRequire))
        {
            storage.Find(res => res.resource == resource.resycleRes).amount += resource.multiplie * PlayerInventory.instance.inventory[resource];
            PlayerInventory.instance.inventory.Remove(resource);
        }
    }
    // Сhecks if there are enough resources to create item
    public bool HashResources(ResourceRequire[] requirements)
    {
        foreach (ResourceRequire require in requirements)
        {
            if (storage.Find(res => res.resource == require.resource).amount < require.amount)
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
            storage.Find(res => res.resource == require.resource).amount -= require.amount;
        }
    }
    // Return actual resourcce quantity
    public float AmountOfResource(ResycleResource resycleResource)
    {
        return storage.Find(res => res.resource == resycleResource).amount;
    }
    // Check building for resycle or upgrade
    public bool CheckRequireBuilding(BuildingRequire[] buildings)
    {
        List<BuildingRequire> _buildings = GameObject.FindGameObjectsWithTag("Building").Select(go => go.GetComponent<BuildingBase>().actualLevel).ToList();
        foreach (var requireBuild in buildings)
        {
            if (_buildings.Find(b => b.type == requireBuild.type).level < requireBuild.level)
            {
                return false;
            }
        }
        return true;
    }
}