using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
// Iterface where resource can be resycle
public class TowerResycle : MonoBehaviour
{
    [HideInInspector] public static TowerResycle instance; // Singletone
    [SerializeField] Transform gridResources; // Grid where resource item is shown
    [SerializeField] Transform quantityResources; // Grid where show amount of resource
    [SerializeField] GameObject prefabItem; // Prefab item with icon
    [SerializeField] GameObject countResourcePrefab; // Prefab for icon and amount 
    [SerializeField] Button buttonResycle; // Resycle button
    [SerializeField] TextMeshProUGUI buildRequire;
    ResourceItem selectItem; // Resource item that seleted for resycle
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
    // Fill resource slots and show progress of each resycle resource
    void Start()
    {
        buttonResycle.onClick.AddListener(ResycleResources);
        FillSlots();
        ShowProgressOfResources();
    }
    // Fill slots resource item
    void FillSlots()
    {
        var _inv = PlayerInventory.instance.inventory;
        if (_inv.Count != 0)
        {
            foreach (var resources in _inv.Keys)
            {
                if (resources is ResourceItem)
                {
                    var _item = Instantiate(prefabItem, gridResources);
                    _item.GetComponent<Image>().sprite = resources.icon;
                    _item.GetComponent<Button>().onClick.AddListener(() => SelectItem(resources));
                    _item.GetComponent<Button>().onClick.AddListener(() => ShowBuildRequire(resources)); 
                }
            }
        }
    }
    // Show quantity of resources in recyle window on TowerUI
    void ShowProgressOfResources()
    {
        foreach (ResourceAmount res in TowerStorage.instance.storage)
        {
            Instantiate(countResourcePrefab, quantityResources).GetComponent<AmountResource>().SetParams(res.resource.icon, res.amount.ToString());
        }
    }
    // Add resource to Storage, refres window, remove item from player inventorys
    void ResycleResources()
    {
        if (selectItem != null && selectItem is ResourceItem)
        {
            TowerStorage.instance.AddResource(selectItem);
            selectItem = null;
            CleanItems();
            FillSlots();
            ShowProgressOfResources();
        }
        else
        {
            return;
        }
    }

    // Clean grid resources from all items in window
    void CleanItems()
    {
        foreach (Transform child in gridResources)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in quantityResources)
        {
            Destroy(child.gameObject);
        }
    }
    // Select resouces from window Tower Interface
    public void SelectItem(Item item)
    {
        if (item is ResourceItem resource)
        {
            TowerResycle.instance.selectItem = resource;
        }
    }
    void ShowBuildRequire(Item item)
    {
        if (item is ResourceItem resource)
        {
            if (TowerStorage.instance.CheckRequireBuilding(resource.buildRequire))
            {
                buildRequire.color = new Color32(81, 205, 81, 255);
                buildRequire.text = "All buildings is exist";
            }
            else
            {
                buildRequire.color = new Color32(205, 81, 81, 255);
                buildRequire.text = "Not all buildings is exist!";
            }
        }
    }

}
