using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Inventory : MonoBehaviour
{
    Button closeButton;
    [SerializeField] GameObject slotPrefab;
    int countSlots = 8;
    Transform parentPanel;
    PlayerController playerController;

    [SerializeField] GameObject itemPrefab;
    void Start()
    {
        closeButton = transform.Find("Close").GetComponent<Button>();
        closeButton.onClick.AddListener(TestClick);
        parentPanel = transform.Find("GridSlots");
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        CreateSlots();
        FillSlots();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void TestClick()
    {
        Destroy(gameObject);
    }
    void CreateSlots()
    {
        for (int i = 0; i < countSlots; i++)
        {
            Instantiate(slotPrefab, parentPanel);
        }

    }

    void FillSlots()
    {
        if (playerController.inventory.Count != 0)
        {
            foreach (var resources in playerController.inventory.Keys)
            {
                var _image = Instantiate(itemPrefab, transform.Find("GridItems")).GetComponent<Image>();
                _image.sprite = Resources.Load<Sprite>($"Sprites/{resources}");
                _image.color = Color.white;
            }
        }

    }
}
