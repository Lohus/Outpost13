using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

// Interaction with Tower
public class Tower : MonoBehaviour
{
    [HideInInspector] public static Tower instance; // Singletone
    [SerializeField] GameObject prefabMenu; // Prefab menu tower
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
    GameObject CreateTowerButton() => Interface.instance.CreateButton("Tower", OnButtonClick);
    // Open Tower Interface window in canvas on scene
    void CreateTowerUI()
    {
        towerUI = Interface.instance.CreateCustomWindow(prefabMenu);
    }
}
