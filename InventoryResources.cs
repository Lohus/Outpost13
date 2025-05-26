using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography.X509Certificates;

//Отображение иконок ресурсов в инвентаре

public class InventoryResources : MonoBehaviour
{
    public GameObject itemPrefab;
    Image[] inventoryObjects;
    PlayerController playerController;
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        CreateSlots();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void CreateSlots()
    {
        if (playerController.inventory.Count != 0)
        {
            foreach (var resources in playerController.inventory.Keys)
            {
                var _image = Instantiate(itemPrefab, gameObject.transform).GetComponent<Image>();
                _image.sprite = Resources.Load<Sprite>($"Sprites/{resources}");
                _image.color = Color.white;
            }
        }

    }
}

