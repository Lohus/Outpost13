using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    [HideInInspector] static TowerUI instance;
    [SerializeField] Button menuResycle;
    [SerializeField] Button menuCraft;
    [SerializeField] Button menuUpgrade;
    [SerializeField] GameObject prefabResycle;
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
        Instantiate(prefabResycle, gameObject.transform);
    } 
} 