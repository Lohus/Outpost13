using UnityEngine;
using UnityEngine.UI;
using TMPro;
// Craft interface
public class CraftUI : MonoBehaviour
{
    [SerializeField] GameObject prefabPanel; // Prefab panel where data is shown
    [SerializeField] Database baseItems; // Base of all items that can be craft
    [SerializeField] GameObject cardWindow; // Place where create prefabPanel
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
                Instantiate(prefabPanel, cardWindow.transform).GetComponent<ItemPanel>().SetItem(item);
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
        TowerStorage.instance.CraftItem(item);
        RefreshWindow();
    }
}