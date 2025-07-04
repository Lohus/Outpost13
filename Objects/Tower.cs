using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

// Interaction with Tower
public class Tower : MonoBehaviour
{
    [HideInInspector] public static Tower instance;
    [SerializeField] GameObject prefabMenu; // Prefab menu tower
    [SerializeField] List<UpgradeBuildings> serializeBuildings;
    public Dictionary<UpgradeBuildings, int> actualBuildings = new();
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
    void Start()
    {
        foreach (var build in serializeBuildings)
        {
            if (actualBuildings.ContainsKey(build))
            {
                actualBuildings[build] = 0;
            }
            else
            {
                actualBuildings.Add(build, 0);
            }
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
        if (PlayerInventory.instance.AddItem(item) && HashResources(item))
        {
            foreach (ResourceRequire require in item.requirements)
            {
                TowerStorage.instance.quantityMaterial[require.nameResource] -= require.amount;
            }
        }
    }

    bool HashResources(CraftItem item)
    {
        foreach (ResourceRequire require in item.requirements)
        {
            if (TowerStorage.instance.quantityMaterial[require.nameResource] < require.amount)
            {
                return false;
            }
        }
        return true;
    }
}
