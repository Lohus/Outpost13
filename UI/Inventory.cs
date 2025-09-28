using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;

// Player inventory
public class Inventory : MonoBehaviour
{
    static Inventory instance; // Singletone
    PlayerInventory playerInventory; // Cache for player inventory
    [SerializeField] GameObject gridItems; // Grid for items
    [SerializeField] GameObject itemPrefab; // Prefab for items
    [SerializeField] TextMeshProUGUI description; // Description of items
    [SerializeField] Button inventoryButton;
    [SerializeField] GameObject prefabPlayerInventory;
    LocalizedString amountOfResource = new LocalizedString("Text_UI", "Amount_UI"); // Table and key
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
        playerInventory = PlayerInventory.instance;
    }
    // Crate and fill slots
    void Start()
    {
        
        FillSlots();
    }
    // Fill slots in grid
    void FillSlots()
    {
        if (playerInventory.inventory.Count != 0)
        {
            foreach (Item resources in playerInventory.inventory.Keys)
            {
                var _item = Instantiate(itemPrefab, gridItems.transform);
                _item.GetComponent<Image>().sprite = resources.icon;
                _item.GetComponent<Button>().onClick.AddListener(() => ShowItemDescription(resources));
            }
        }
    }
    // Show item description in panel
    void ShowItemDescription(Item res)
    {
        string descriptionString = "";
        if (playerInventory.inventory[res] >= 2)
        {
            //amountOfResource.Arguments = new object[] { playerInventory.inventory[res] };
            amountOfResource.StringChanged += (text) => { descriptionString += text + playerInventory.inventory[res] + "\n"; };
        }
        res.description.StringChanged += (text) =>
        {
            description.text = descriptionString + text; 
        };
    }
    void OpenInventory()
    {
        inventoryButton.interactable = false;
        Interface.instance.CreateCustomWindow(prefabPlayerInventory);
    }
}
