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
    [HideInInspector] public GameObject selectItem;
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
                _item.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/{resources}");
                _item.GetComponent<Button>().onClick.AddListener(() => SelectItem(_item));

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
    public void SelectItem(GameObject gO)
    {
        TowerInterface.instance.selectItem = gO;
        Debug.Log(selectItem);
    }


}
