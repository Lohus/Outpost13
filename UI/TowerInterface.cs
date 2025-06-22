using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerInterface : MonoBehaviour
{
    [SerializeField] Transform gridResources;
    [SerializeField] GameObject itemPrefab;
    public static TowerInterface instance;
    [HideInInspector] public ResourceItem selectItem;
    [SerializeField] List<GameObject> progress = new List<GameObject> { };
    public void Awake()
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
        transform.Find("Close").GetComponent<Button>().onClick.AddListener(CloseInventory);
        transform.Find("Resycle").GetComponent<Button>().onClick.AddListener(ResycleResources);
        FillSlots();
        ShowProgressOfResources();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FillSlots()
    {
        var _inv = PlayerInventory.instance.inventory;
        if (_inv.Count != 0)
        {
            foreach (var resources in _inv.Keys)
            {
                var _item = Instantiate(itemPrefab, gridResources);
                _item.GetComponent<Image>().sprite = resources.icon;
                _item.GetComponent<Button>().onClick.AddListener(() => SelectItem(resources));

            }
        }

    }
    public void CloseInventory()
    {
        Destroy(gameObject);
    }
    // Show quantity of resources in window Tower Interface 
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
        if (selectItem != null)
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
    public void SelectItem(ResourceItem resource)
    {
        TowerInterface.instance.selectItem = resource;
    }


}
