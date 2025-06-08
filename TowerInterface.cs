using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerInterface : MonoBehaviour
{
    public static TowerInterface instance;
    [SerializeField] GameObject biomassProgress;
    [SerializeField] GameObject metalProgress;
    [SerializeField] GameObject polycristalProgress;
    [SerializeField] GameObject isotopeProgress;
    [SerializeField] Transform gridResources;
    [SerializeField] GameObject itemPrefab;
    [HideInInspector] public ResourceItem selectItem;
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
        FillSlots();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FillSlots()
    {
        var _inv = PlayerController.instance.inventory;
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

    }
    void ResycleResources()
    {

    }
    // Select resouces from window Tower Interface
    public void SelectItem(ResourceItem resource)
    {
        TowerInterface.instance.selectItem = resource;
        Debug.Log(selectItem.name);
    }


}
