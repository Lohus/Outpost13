using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections.Generic;
// Upgrade building interface
public class UpgradeUI : MonoBehaviour
{
    [HideInInspector] public static UpgradeUI instance; // Singletone
    [SerializeField] GameObject prefabPanel; // Prefab panel where data is shown
    [SerializeField] GameObject cardWindow; // Place where create prefabPanel
    BuildingBase[] buildings; // All buildings that can be upgrade on scene
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
    // Find all buildings on scene and show panel
    void Start()
    {
        buildings = GameObject.FindGameObjectsWithTag("Building").Select(go => go.GetComponent<BuildingBase>()).ToArray();
        ShowUpgrade();
    }
    // Show data for every upgrade
    void ShowUpgrade()
    {
        foreach (BuildingBase building in buildings)
        {
            foreach (LevelBuildings level in building.chainUpgrade)
            {
                if (building.actualLevel.level + 1 == level.level)
                {
                    GameObject _card = Instantiate(prefabPanel, cardWindow.transform);
                    _card.transform.Find("Icon").GetComponent<Image>().sprite = level.icon;
                    _card.transform.Find("RightGroup/Name").GetComponent<TextMeshProUGUI>().text = building.actualLevel.type.name;
                    _card.transform.Find("RightGroup/Button").GetComponent<Button>().onClick.AddListener(() => building.LevelUP(level));
                    _card.transform.Find("RightGroup/Button").GetComponent<Button>().onClick.AddListener(() => RefreshWindow());
                }
            }
        }
    }
    // Refresh window 
    void RefreshWindow()
    {
        foreach (Transform child in cardWindow.transform)
        {
            Destroy(child.gameObject);
        }
        ShowUpgrade();
    }
}