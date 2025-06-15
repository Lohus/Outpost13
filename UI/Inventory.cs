using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class Inventory : MonoBehaviour
{
    Button closeButton;
    [SerializeField] GameObject slotPrefab;
    int countSlots = 8;
    Transform parentPanel; // Canvas
    PlayerInventory playerInventory;
    [SerializeField] TextMeshProUGUI description;

    [SerializeField] GameObject itemPrefab;
    void Awake()
    {
        playerInventory = PlayerInventory.instance;
    }
    void Start()
    {
        closeButton = transform.Find("Close").GetComponent<Button>();
        closeButton.onClick.AddListener(CloseInventory);
        parentPanel = transform.Find("GridSlots");
        CreateSlots();
        FillSlots();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void CloseInventory()
    {
        Destroy(gameObject);
    }
    void CreateSlots()
    {
        for (int i = 0; i < countSlots; i++)
        {
            Instantiate(slotPrefab, parentPanel);
        }

    }

    void FillSlots()
    {
        if (playerInventory.inventory.Count != 0)
        {
            Transform _GridItems = transform.Find("GridItems");
            foreach (var resources in playerInventory.inventory.Keys)
            {
                var _item = Instantiate(itemPrefab, _GridItems);
                _item.GetComponent<Image>().sprite = resources.icon;
                _item.GetComponent<Button>().onClick.AddListener(() => ShowItemDescription(resources));

            }
        }

    }

    public void ShowItemDescription(ResourceItem res)
    {
        transform.Find("Description").GetComponentInChildren<TextMeshProUGUI>().text = playerInventory.inventory[res] + "\n" + res.description;
    }
}
