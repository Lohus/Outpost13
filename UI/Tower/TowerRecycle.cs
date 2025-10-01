using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
// Iterface where resource can be resycle
public class TowerRecycle : MonoBehaviour
{
    [SerializeField] Transform gridResources; // Grid where resource item is shown
    [SerializeField] Transform quantityResources; // Grid where show amount of resource
    [SerializeField] GameObject prefabItem; // Prefab item with icon
    [SerializeField] GameObject countResourcePrefab; // Prefab for icon and amount 
    [SerializeField] Button buttonRecycle; // Resycle button
    [SerializeField] TextMeshProUGUI buildRequire;
    ResourceItem selectItem; // Resource item that seleted for resycle
    // Fill resource slots and show progress of each resycle resource
    void Start()
    {
        buttonRecycle.onClick.AddListener(ResycleResources);
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
            Instantiate(countResourcePrefab, quantityResources).GetComponent<AmountResource>().SetParams(res);
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
            selectItem = resource;
        }
    }
    // Check all build is exist
    void ShowBuildRequire(Item item)
    {
        LocalizedString allBuilding = new LocalizedString("Text_UI", "AllBuilding_UI");
        LocalizedString specificBuilding = new LocalizedString("Text_UI", "SpecificBuilding_UI");
        if (item is ResourceItem resource)
        {
            buildRequire.text = " ";
            List<BuildingRequire> _buildings = TowerStorage.instance.ReturnRequireBuildings(resource.buildRequire);
            if (_buildings.Count == 0)
            {
                buildRequire.color = new Color32(81, 205, 81, 255);
                allBuilding.StringChanged += (text) => { buildRequire.text = text;};
                buttonRecycle.interactable = true;
            }
            else
            {
                buildRequire.color = new Color32(205, 81, 81, 255);
                buildRequire.text = "";
                string nameBuilding = "";
                foreach (BuildingRequire build in _buildings)
                {
                    build.type.typeBuildings.StringChanged += (text) =>
                    {
                        nameBuilding = text;
                        specificBuilding.Arguments = new object[] { nameBuilding, build.level };
                        specificBuilding.StringChanged += (text) => { buildRequire.text += text + "\n"; };
                    };
                }
            }
        }
    }
}
