using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Security.Cryptography.X509Certificates;


public class Inventory : MonoBehaviour
{
    Button closeButton;
    [SerializeField] GameObject slotPrefab;
    int countSlots = 8;
    Transform parentPanel; // Canvas
    PlayerController playerController;
    [SerializeField] TextMeshProUGUI description;

    [SerializeField] GameObject itemPrefab;
    void Start()
    {
        closeButton = transform.Find("Close").GetComponent<Button>();
        closeButton.onClick.AddListener(CloseInventory);
        parentPanel = transform.Find("GridSlots");
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        CreateSlots();
        FillSlots();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void CloseInventory()
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
            Transform _GridItems = transform.Find("GridItems");
            foreach (var resources in playerController.inventory.Keys)
            {
                var _image = Instantiate(itemPrefab, _GridItems);
                _image.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/{resources}");
                _image.GetComponent<Button>().onClick.AddListener(() => ShowItemDescription(resources));

            }
        }

    }

    public void ShowItemDescription(string res)
    {
        transform.Find("Description").GetComponentInChildren<TextMeshProUGUI>().text = res + ' ' + playerController.inventory[res];
    }
}
