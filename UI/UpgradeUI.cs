using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public static UpgradeUI instance;
    [SerializeField] GameObject prefabPanel;
    [SerializeField] GameObject cardWindow;
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
        ShowItems();
    }
    void ShowItems()
    {
        var _buildList = Tower.instance.actualBuildings;
        foreach (UpgradeBuildings typeBuilding in _buildList.Keys)
        {
            foreach (LevelBuildings level in typeBuilding.chainUpgrade)
            {
                if (_buildList[typeBuilding] + 1 == level.level)
                {
                    GameObject _card = Instantiate(prefabPanel, cardWindow.transform);
                    _card.transform.Find("Icon").GetComponent<Image>().sprite = level.icon;
                    _card.transform.Find("RightGroup/Description").GetComponent<TextMeshProUGUI>().text = typeBuilding.nameBuildings;
                    //_card.transform.Find("RightGroup/Button").GetComponent<Button>().onClick.AddListener(() => PressButton(item));

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
        ShowItems();
    }

    void PressButton(CraftItem item)
    {
        Tower.instance.CraftItem(item);
        RefreshWindow();
    }
}