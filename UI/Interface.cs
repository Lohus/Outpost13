using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Interface : MonoBehaviour
{
    public Transform parentPanel; // Canvas on scene
    public GameObject buttonPrefabs;
    public GameObject inventoryPrefabs;
    string nameButtonInventory;
    string nameInventoryTower;

    void Start()
    {
        parentPanel = gameObject.transform;
        CreateInventoryButton();
    }

    // Update is called once per frame
    void Update()
    {

    }
    string CreateInventoryButton()
    {
        // Уместить в одну строчку без доп. переменных
        GameObject button = Instantiate(buttonPrefabs, parentPanel);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        button.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
        button.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, -20);
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = "Inventory";
        Button buttonComponent = button.GetComponent<Button>();
        buttonComponent.onClick.AddListener(CreateInventoryWindow);
        button.name = "OpenInventory";
        return button.name;
    }

    public void CreateInventoryWindow()
    {

        if (nameInventoryTower == null)
        {
            nameInventoryTower = Instantiate(inventoryPrefabs, parentPanel).name;
        }

        else if (!parentPanel.transform.Find(nameInventoryTower))
        {
            nameInventoryTower = Instantiate(inventoryPrefabs, parentPanel).name;
        }
    }
}
