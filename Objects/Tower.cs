using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

// Interaction with Tower
public class Tower : MonoBehaviour
{
    [HideInInspector] public static Tower instance; // Singletone
    [SerializeField] GameObject prefabMenu; // Prefab menu tower
    LocalizedString towerLocal = new LocalizedString { TableReference = "Text_UI", TableEntryReference = "OpenTerminalButton_UI" };
    GameObject buttonTower; // Button for open tower interface
    GameObject towerUI; // Tower interface 

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
    // Show button of tower UI
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            buttonTower = CreateTowerButton();
        }
    }
    // Destroy button and destroy Tower Interface
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(buttonTower);
            Destroy(towerUI);
        }
    }
    // Open Tower Interface
    public void OnButtonClick()
    {
        CreateTowerUI();
    }
    // Create button that open tower interface
    GameObject CreateTowerButton()
    {
        string localizedTextButton = null;
        towerLocal.StringChanged += (localizedText) =>
        {
            localizedTextButton = localizedText;
        };
        return Interface.instance.CreateButton(localizedTextButton, OnButtonClick);
    }
    // Open Tower Interface window in canvas on scene
    void CreateTowerUI()
    {
        towerUI = Interface.instance.CreateCustomWindow(prefabMenu);
    }
}
