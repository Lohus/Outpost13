using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class Inventory : MonoBehaviour
{
    static Inventory instance;
    int countSlots = 8; // Count of slots
    PlayerInventory playerInventory;
    [SerializeField] GameObject gridSlots;
    [SerializeField] GameObject gridItems;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] TextMeshProUGUI description;
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
    void Start()
    {
        CreateSlots();
        FillSlots();
    }

    void Update()
    {
    }
    void CreateSlots()
    {
        for (int i = 0; i < countSlots; i++)
        {
            Instantiate(slotPrefab, gridSlots.transform);
        }

    }

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
    void ShowItemDescription(Item res)
    {
        transform.Find("Description").GetComponentInChildren<TextMeshProUGUI>().text = playerInventory.inventory[res] + "\n" + res.description;
    }
}
