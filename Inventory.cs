using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Inventory : MonoBehaviour
{
    Button closeButton;
    [SerializeField] GameObject slotPrefab;
    int countSlots = 8;
    Transform parentPanel;
    Image[] inventoryObjects;
    PlayerController playerController;
    void Start()
    {
        closeButton = transform.Find("Close").GetComponent<Button>();
        closeButton.onClick.AddListener(TestClick);
        parentPanel = transform.Find("InventorySlots");
        CreateSlots();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void TestClick()
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
}
