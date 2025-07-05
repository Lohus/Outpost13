using UnityEngine;
using UnityEngine.UI;
using TMPro;
// Craft interface
public class CraftUI : MonoBehaviour
{
    [HideInInspector] public static CraftUI instance; // Singletone
    [SerializeField] GameObject prefabPanel; // Prefab panel where data is shown
    [SerializeField] Database baseItems; // Base of all items that can be craft
    [SerializeField] GameObject cardWindow; // Place where create prefabPanel
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
    // Show all crafted item in card window
    void Start()
    {
        ShowItems();
    }
    // Create panel with data
    void ShowItems()
    {
        foreach (CraftItem item in baseItems.allCraftItems)
        {
            if (PlayerInventory.instance.CheckItem(item) == false)
            {
                GameObject _card = Instantiate(prefabPanel, cardWindow.transform);
                _card.transform.Find("Icon").GetComponent<Image>().sprite = item.icon;
                _card.transform.Find("RightGroup/Description").GetComponent<TextMeshProUGUI>().text = item.nameItem;
                _card.transform.Find("RightGroup/Button").GetComponent<Button>().onClick.AddListener(() => PressButton(item));
            }
        }
    }
    // Refresh window with panel
    void RefreshWindow()
    {
        foreach (Transform child in cardWindow.transform)
        {
            Destroy(child.gameObject);
        }
        ShowItems();
    }
    // Create item and refresh window
    void PressButton(CraftItem item)
    {
        Tower.instance.CraftItem(item);
        RefreshWindow();
    }
}