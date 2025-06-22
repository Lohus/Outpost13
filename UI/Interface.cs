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
    [HideInInspector] public static Interface instance;
    Transform mainUI; // Canvas on scene
    [SerializeField] GameObject buttonPrefabs;
    [SerializeField] GameObject inventoryPrefabs;
    [SerializeField] GameObject prefabProgressBar;
    [SerializeField] GameObject prefabBasePanel;
    [SerializeField] GameObject prefabPlayerInventory;

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
        buttonComponent.onClick.AddListener(() => CreateCustomWindow(prefabPlayerInventory));
        button.name = "OpenInventory";
        return button.name;
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
        var _bar = Instantiate(prefabProgressBar, gameObject.transform);
        _bar.GetComponent<ProgressBar>().Init(durationAnimation);
        return _bar;
    }
    GameObject CreateBaseWindow()
    {
        var _panel = Instantiate(prefabBasePanel, gameObject.transform);
        _panel.GetComponentInChildren<Button>().onClick.AddListener(() => Destroy(_panel));
        return _panel;

    }
    public GameObject CreateCustomWindow(GameObject prefab)
    {
        var _panel = CreateBaseWindow();
        Instantiate(prefab, _panel.transform);
        return _panel;
    }
}
