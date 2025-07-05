using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
// General interface of Tower
public class TowerUI : MonoBehaviour
{
    [HideInInspector] static TowerUI instance; // Singletone
    [SerializeField] Button menuResycle, menuCraft, menuUpgrade; // Simple menu
    [SerializeField] GameObject prefabResycle, prefabCraft, prefabUpgrade; // Prefabs for resycle, craft, upgrade
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
        menuResycle.onClick.AddListener(() => OpenPrefab(prefabResycle));
        menuCraft.onClick.AddListener(() => OpenPrefab(prefabCraft));   
        menuUpgrade.onClick.AddListener(() => OpenPrefab(prefabUpgrade));   
        existPrefab = Instantiate(prefabResycle, gameObject.transform);   
    }
    // Open resycle prefab
    void OpenPrefab(GameObject prefab)
    {
        if (existPrefab != null)
        {
            Destroy(existPrefab);
        }
        existPrefab = Instantiate(prefab, gameObject.transform);
    }
} 