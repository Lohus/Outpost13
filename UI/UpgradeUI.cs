using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections.Generic;

public class UpgradeUI : MonoBehaviour
{
    public static UpgradeUI instance;
    [SerializeField] GameObject prefabPanel;
    [SerializeField] GameObject cardWindow;
    BuildingBase[] buildings;
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
        buildings = GameObject.FindGameObjectsWithTag("Building").Select(go => go.GetComponent<BuildingBase>()).ToArray();
        ShowUpgrade();
    }
    void ShowUpgrade()
    {
        foreach (BuildingBase building in buildings)
        {
            foreach (LevelBuildings level in building.chainUpgrade)
            {
                if (building.actualLevel + 1 == level.level)
                {
                    GameObject _card = Instantiate(prefabPanel, cardWindow.transform);
                    _card.transform.Find("Icon").GetComponent<Image>().sprite = level.icon;
                    _card.transform.Find("RightGroup/Description").GetComponent<TextMeshProUGUI>().text = building.nameBuilding;
                    _card.transform.Find("RightGroup/Button").GetComponent<Button>().onClick.AddListener(() => building.LevelUP(level));

                }
            }
        }
    }
    void RefreshWindow()
    {
        foreach (Transform child in cardWindow.transform)
        {
            Destroy(child.gameObject);
        }
        ShowUpgrade();
    }

    void PressButton(CraftItem item)
    {
        Tower.instance.CraftItem(item);
        RefreshWindow();
    }
}