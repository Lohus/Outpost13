
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Взаимодествие с форпостом
public class Tower : MonoBehaviour
{
    public static Tower instance;
    public Transform parentPanel;
    public GameObject inventoryPrefabs;
    GameObject buttonTower;
    string nameTowerWindow;
    public Dictionary<string, float> quantityMaterial = new Dictionary<string, float> {{"biomass", 0}, {"metal", 0}, {"poly", 0}, {"iso", 0}};

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

    }

    // Update is called once per frame
    void Update()
    {

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
            Destroy(GameObject.Find(nameTowerWindow));
        }
    }
    public void OnButtonClick()
    {
        CreateTowerWindow();
    }
    GameObject CreateTowerButton() => Interface.instance.CreateButton("Tower", OnButtonClick);
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
