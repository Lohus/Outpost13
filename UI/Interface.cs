using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

// Add to Canvas on scene
public class Interface : MonoBehaviour
{
    public static Interface instance;
    public Transform mainUI; // Canvas on scene
    public GameObject buttonPrefabs;
    public GameObject inventoryPrefabs;
    string nameInventoryTower;
    [SerializeField] GameObject progressBarPrefab;

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
        mainUI = gameObject.transform;
    }
    void Start()
    {
        CreateInventoryButton();
    }

    // Update is called once per frame
    void Update()
    {

    }
    string CreateInventoryButton()
    {
        // Уместить в одну строчку без доп. переменных
        GameObject button = Instantiate(buttonPrefabs, mainUI);
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
            nameInventoryTower = Instantiate(inventoryPrefabs, mainUI).name;
        }

        else if (!mainUI.transform.Find(nameInventoryTower))
        {
            nameInventoryTower = Instantiate(inventoryPrefabs, mainUI).name;
        }
    }

    public GameObject CreateButton(string textOnButton, Action OnButtonClick)
    {
        GameObject button = Instantiate(buttonPrefabs, mainUI);
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = textOnButton;
        Button buttonComponent = button.GetComponent<Button>();
        buttonComponent.onClick.AddListener(() => OnButtonClick?.Invoke());
        return button;
    }

    public GameObject CreateProgressBar(float durationAnimation)
    {
        var _bar = Instantiate(progressBarPrefab, gameObject.transform);
        _bar.GetComponent<ProgressBar>().Init(durationAnimation);
        return _bar;
    }
}
