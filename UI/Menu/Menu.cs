using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject basePanel;
    [SerializeField] GameObject settingsPrefab;
    [SerializeField] Button settings, returnGame, mainMenu, newGame, loadGame;
    [SerializeField] Transform canvas;
    [SerializeField] SettingsGame settingsGame;
    void Start()
    {
        if (canvas == null)
        {
            canvas = transform.parent;
        }
        //returnGame.onClick.AddListener(CloseMenu);
        AddClick(returnGame, CloseMenu);
        //settings.onClick.AddListener(OpenSettings);
        AddClick(settings, OpenSettings);
        //mainMenu.onClick.AddListener(OpenStartMenu);
        AddClick(mainMenu, OpenStartMenu);
        AddClick(newGame, OpenMainLevel);
        AddClick(loadGame, LoadGame);
    }
    public void OpenMainLevel()
    {
        settingsGame.save = false;
        SceneManager.LoadScene("MainLevel");
    }
    public void OpenSettings()
    {
        GameObject _panel = Instantiate(basePanel, canvas);
        _panel.GetComponentInChildren<Button>().onClick.AddListener(() => Destroy(_panel));
        Instantiate(settingsPrefab, _panel.transform);
    }
    void CloseMenu()
    {
        Destroy(gameObject);
    }
    void OpenStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    void AddClick(Button button, Action buttonClick)
    {
        if (button == null) return;
        button.onClick.AddListener(() => buttonClick());
    }
    void LoadGame()
    {
        settingsGame.save = true;
        SceneManager.LoadScene("MainLevel");
    }
}