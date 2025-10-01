using UnityEngine;
using UnityEngine.UI;
// General interface of Tower
public class TowerUI : MonoBehaviour
{
    [HideInInspector] static TowerUI instance; // Singletone
    [SerializeField] Button menuResycle, menuCraft, menuUpgrade; // Simple menu
    [SerializeField] GameObject prefabRecycle, prefabCraft, prefabUpgrade; // Prefabs for resycle, craft, upgrade
    GameObject existPrefab; // Base menu prefab
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
        menuResycle.onClick.AddListener(() => OpenPrefab(prefabRecycle));
        menuCraft.onClick.AddListener(() => OpenPrefab(prefabCraft));   
        menuUpgrade.onClick.AddListener(() => OpenPrefab(prefabUpgrade));
        menuResycle.Select();   
        existPrefab = Instantiate(prefabRecycle, transform.parent);   
    }
    // Open resycle prefab
    void OpenPrefab(GameObject prefab)
    {
        if (existPrefab != null)
        {
            Destroy(existPrefab);
        }
        existPrefab = Instantiate(prefab, transform.parent);
    }
} 