using UnityEngine;
using System.Collections.Generic;

// Interaction with Outpost
public class Tower : MonoBehaviour
{
    [HideInInspector] public static Tower instance;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            buttonTower = CreateTowerButton();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(buttonTower);
            Destroy(towerUI);
        }
    }
    public void OnButtonClick()
    {
        CreateTowerUI();
    }
    GameObject CreateTowerButton() => Interface.instance.CreateButton("Tower", OnButtonClick);
    void CreateTowerUI()
    {
        towerUI = Interface.instance.CreateCustomWindow(prefabMenu);
    }
    public void CraftItem(CraftItem item)
    {
        foreach (ResourceRequire require in item.requirements)
        {
            if (TowerStorage.instance.quantityMaterial[require.nameResource] < require.amount)
            {
                return;
            }
        }
        if (PlayerInventory.instance.AddItem(item))
        {
            foreach (ResourceRequire require in item.requirements)
            {
                TowerStorage.instance.quantityMaterial[require.nameResource] -= require.amount;
            }
        }
    }
}
