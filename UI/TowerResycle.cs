using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerResycle : MonoBehaviour
{
    public static TowerResycle instance;
    [SerializeField] Transform gridResources;
    [SerializeField] GameObject prefabItem;
    [SerializeField] List<GameObject> progress = new List<GameObject> { };
    [SerializeField] Button buttonResycle;
    ResourceItem selectItem;
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

    void Start()
    {
        buttonResycle.onClick.AddListener(ResycleResources);
        FillSlots();
        ShowProgressOfResources();
    }
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
