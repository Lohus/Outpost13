using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

// Player inventory
public class Inventory : MonoBehaviour
{
    static Inventory instance; // Singletone
    PlayerInventory playerInventory; // Cache for player inventory
    [SerializeField] GameObject gridSlots; // Grid for slots
    [SerializeField] GameObject gridItems; // Grid for items
    [SerializeField] GameObject slotPrefab; // Prefab for slots
    [SerializeField] GameObject itemPrefab; // Prefab for items
    [SerializeField] TextMeshProUGUI description; // Description of items
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
            descriptionString += $"Amount of resource: {playerInventory.inventory[res]}\n";
        }
        transform.Find("Description").GetComponentInChildren<TextMeshProUGUI>().text = descriptionString + res.description;
    }
}
