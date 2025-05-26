using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SceneManagement;

// Взаимодествие с форпостом
public class Tower : MonoBehaviour
{
    public Transform parentPanel;
    public GameObject buttonPrefabs;
    public GameObject inventoryPrefabs;
    string nameButtonInventory;
    string nameInventoryTower;
    int levelTower = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            nameButtonInventory = CreateInventoryButton();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(GameObject.Find(nameButtonInventory));
            Destroy(GameObject.Find(nameInventoryTower));
        }
    }
    public void OnButtonClick()
    {
        CreateInventoryWindow();
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
        buttonComponent.onClick.AddListener(OnButtonClick);
        return button.name;
    }
    void CreateInventoryWindow()
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
