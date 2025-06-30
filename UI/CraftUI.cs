using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftUI : MonoBehaviour
{
    public static CraftUI instance;
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
            _card.transform.Find("RightGroup/Description").GetComponent<TextMeshProUGUI>().text = item.itemName;
            _card.transform.Find("RightGroup/Button").GetComponent<Button>().onClick.AddListener(() => PressButton(item.requirements));
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

    void PressButton(ResourceRequire[] requires)
    {
        Tower.instance.CraftItem(requires);
        RefreshWindow();
    }
}