using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Localization;

// General interface to create UI element
public class Interface : MonoBehaviour
{
    [HideInInspector] public static Interface instance; // Singletone
    Transform mainUI; // Canvas on scene
    [SerializeField] GameObject buttonWindow; // Base Button
    [SerializeField] GameObject prefabProgressBar; // Progressbar
    [SerializeField] GameObject prefabBasePanel; // Base panel
    [SerializeField] GameObject prefabPlayerInventory; // Player inventory
    [SerializeField] Image healthBar;
    GameObject inventoryPanel;
    [SerializeField] LocalizedString inventoryLocalized;

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
    // Create inventory button
    void Start()
    {
        CreateInventoryButton();
    }
    // Button player inventory
    string CreateInventoryButton()
    {
        // Уместить в одну строчку без доп. переменных
        GameObject button = Instantiate(buttonWindow, mainUI);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        button.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
        button.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, -20);
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        inventoryLocalized.StringChanged += (localizedText) =>
            {
                buttonText.text = localizedText;
            };
        //buttonText.text = "Inventory";
        Button buttonComponent = button.GetComponent<Button>();
        buttonComponent.onClick.AddListener(() => CreateCustomWindow(prefabPlayerInventory));
        button.name = "OpenInventory";
        return button.name;
    }
    // Create base button with params
    public GameObject CreateButton(string textOnButton, Action OnButtonClick)
    {
        GameObject button = Instantiate(buttonWindow, mainUI);
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = textOnButton;
        Button buttonComponent = button.GetComponent<Button>();
        buttonComponent.onClick.AddListener(() => OnButtonClick?.Invoke());
        return button;
    }
    // Create progressbar with params
    public GameObject CreateProgressBar(float durationAnimation)
    {
        var _bar = Instantiate(prefabProgressBar, gameObject.transform);
        _bar.GetComponent<ProgressBar>().Init(durationAnimation);
        return _bar;
    }
    // Create base window
    GameObject CreateBaseWindow()
    {

        var basePanel = Instantiate(prefabBasePanel, gameObject.transform);
        basePanel.GetComponentInChildren<Button>().onClick.AddListener(() => Destroy(basePanel));
        return basePanel;
    }
    // Create custom window from other UI
    public GameObject CreateCustomWindow(GameObject prefab)
    {
        var _panel = CreateBaseWindow();
        Instantiate(prefab, _panel.transform);
        return _panel;
    }
    public void UpdateHealthBar()
    {
        healthBar.fillAmount = PlayerController.instance.actualHealth / PlayerController.instance.maxHealth;
    }
}
