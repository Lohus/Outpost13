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
    [SerializeField] GameObject prefabItem; // Prefab item with icon
    [SerializeField] List<GameObject> progress = new List<GameObject> { }; // Progressbar of each resycle resource
    [SerializeField] Button buttonResycle; // Resycle button
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
                }

            }
        }
    }
    // Show quantity of resources in recyle window on TowerUI
    void ShowProgressOfResources()
    {
        var _quantity = TowerStorage.instance.quantityMaterial;
        foreach (var res in progress)
        {
            var _trans = res.GetComponent<RectTransform>();
            _trans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 144 * _quantity[res.name] / 100);
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
    }
    // Select resouces from window Tower Interface
    public void SelectItem(Item item)
    {
        if (item is ResourceItem resource)
        {
            TowerResycle.instance.selectItem = resource;
        }
    }


}
