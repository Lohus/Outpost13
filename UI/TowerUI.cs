using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    [HideInInspector] static TowerUI instance;
    [SerializeField] Button menuResycle, menuCraft, menuUpgrade;
    [SerializeField] GameObject prefabResycle, prefabCraft, prefabUpgrade;
    GameObject existPrefab;
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
    void OpenPrefab(GameObject prefab)
    {
        if (existPrefab != null)
        {
            Destroy(existPrefab);
        }
        existPrefab = Instantiate(prefab, gameObject.transform);
    }
} 