using UnityEngine;
using UnityEngine.UI;

public class OpenPrefs : MonoBehaviour
{
    [SerializeField] Button mainButton; // Button that opens prefab
    [SerializeField] GameObject prefab;
    [SerializeField] Transform parent;
    GameObject actualPrefabs;
    void Start()
    {
        mainButton.onClick.AddListener(ButtonPress);
    }
    void Update()
    {
        if (actualPrefabs == null)
        {
            mainButton.interactable = true;
        }
    }

    void ButtonPress()
    {
        actualPrefabs = Instantiate(prefab, parent);
        mainButton.interactable = false;
    }
}