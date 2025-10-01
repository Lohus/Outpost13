// Final scene play sound and show CAIT message
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    [SerializeField] Button send;
    [SerializeField] SettingsGame settings;
    void Start()
    {
        AudioListener.volume = settings.volume;
        send.onClick.AddListener(() => Send());
    }
    void Send()
    {
        SceneManager.LoadScene("StartMenu");
    }
}