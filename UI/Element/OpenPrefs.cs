using UnityEngine;
using UnityEngine.UI;

public class OpenPrefs : MonoBehaviour
{
    [SerializeField] Button mainButton; // Button that opens prefab
    [SerializeField] GameObject prefab;
    [SerializeField] Transform parent;
    [SerializeField] bool useBasePanel = false;
    GameObject actualPrefabs;
    public delegate GameObject InstantPrefabFunction(GameObject gameObject, Transform parent);
    [SerializeField] InstantPrefabFunction prefabFunction;
    void Start()
    {
        mainButton.onClick.AddListener(ButtonPress);
        prefabFunction = useBasePanel ? InstantiateCustomPrefab : InstantiatePrefab;
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
        actualPrefabs = prefabFunction(prefab, parent);
        mainButton.interactable = false;
    }
    public GameObject InstantiatePrefab(GameObject prefab, Transform parent) => Instantiate(prefab, parent);
    public GameObject InstantiateCustomPrefab(GameObject prefab, Transform parent) => Interface.instance.CreateCustomWindow(prefab, parent);
}