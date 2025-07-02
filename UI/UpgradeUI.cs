using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public static UpgradeUI instance;
    [SerializeField] GameObject prefabPanel;
    [SerializeField] Database baseItems;
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
        foreach (CraftItem item in baseItems.allCraftItems)
        {
            GameObject _card = Instantiate(prefabPanel, cardWindow.transform);
            _card.transform.Find("Icon").GetComponent<Image>().sprite = item.icon;
            _card.transform.Find("RightGroup/Description").GetComponent<TextMeshProUGUI>().text = item.nameItem;
            _card.transform.Find("RightGroup/Button").GetComponent<Button>().onClick.AddListener(() => PressButton(item));
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