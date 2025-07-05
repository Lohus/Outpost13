using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

// Interaction with Tower
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
        if (HashResources(item.requirements))
        {
           if (PlayerInventory.instance.AddItem(item))
            {
                TakeResources(item.requirements);
            } 
        }
    }

    public bool HashResources(ResourceRequire[] requirements)
    {
        foreach (ResourceRequire require in requirements)
        {
            if (TowerStorage.instance.quantityMaterial[require.nameResource] < require.amount)
            {
                return false;
            }
        }
        return true;
    }

    public void TakeResources(ResourceRequire[] requirements)
    {
        foreach (ResourceRequire require in requirements)
        {
            TowerStorage.instance.quantityMaterial[require.nameResource] -= require.amount;
        }
    }
}
