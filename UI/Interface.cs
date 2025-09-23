using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SocialPlatforms.Impl;
using YG;
using System.Collections;

// General interface to create UI element
public class Interface : MonoBehaviour
{
    [HideInInspector] public static Interface instance; // Singletone
    Transform mainUI; // Canvas on scene
    [SerializeField] GameObject buttonWindow; // Base Button
    [SerializeField] GameObject prefabProgressBar; // Progressbar
    [SerializeField] GameObject prefabBasePanel; // Base panel
    [SerializeField] SettingsGame settings;
    [SerializeField] GameObject caitUI;
    [SerializeField] public GameObject joystick;
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
        joystick.SetActive(!settings.keyboardControl);
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
    public GameObject CreateCustomWindow(GameObject prefab, Transform parent)
    {
        var _panel = CreateBaseWindow();
        Instantiate(prefab, _panel.transform);
        return _panel;
    }
    public void SetJoystick(bool status)
    {
        joystick.SetActive(status);
    }
    public void CreateMessage(CaitMessage message)
    {
        Instantiate(caitUI, mainUI).GetComponent<CaitUI>().Init(message.icon, message.message);
    }
}
