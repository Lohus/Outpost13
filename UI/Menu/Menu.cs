using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject basePanel;
    [SerializeField] GameObject settingsPrefab;
    [SerializeField] Button settings, returnGame, mainMenu, newGame;
    [SerializeField] Transform canvas;
    void Start()
    {
        if (canvas == null)
        {
            canvas = transform.parent;
        }
        returnGame.onClick.AddListener(CloseMenu);
        settings.onClick.AddListener(OpenSettings);
    }
    public void OpenScene()
    {
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
}