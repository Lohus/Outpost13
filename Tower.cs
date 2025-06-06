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
    string nameButtonTower;
    string nameTowerWindow;
    Dictionary<string, int> quantityMaterial = new Dictionary<string, int> { {"biomass", 0} };

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
            nameButtonTower = CreateTowerButton();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(GameObject.Find(nameButtonTower));
            Destroy(GameObject.Find(nameTowerWindow));
        }
    }
    public void OnButtonClick()
    {
        CreateTowerWindow();
    }
    string CreateTowerButton()
    {
        // Уместить в одну строчку без доп. переменных
        GameObject button = Instantiate(buttonPrefabs, parentPanel);
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = "Tower";
        Button buttonComponent = button.GetComponent<Button>();
        buttonComponent.onClick.AddListener(OnButtonClick);
        return button.name;
    }
    void CreateTowerWindow()
    {

        if (nameTowerWindow == null)
        {
            nameTowerWindow = Instantiate(inventoryPrefabs, parentPanel).name;
        }

        else if (!parentPanel.transform.Find(nameTowerWindow))
        {
            nameTowerWindow = Instantiate(inventoryPrefabs, parentPanel).name;
        }
    }
}
