using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerInterface : MonoBehaviour
{
    [SerializeField] GameObject biomassProgress;
    [SerializeField] GameObject metalProgress;
    [SerializeField] GameObject polycristalProgress;
    [SerializeField] GameObject isotopeProgress;
    [SerializeField] Transform gridResources;
    [SerializeField] GameObject itemPrefab;

    void Start()
    {
        FillSlots();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void FillSlots()
    {
        var _inv = PlayerController.instance.inventory;
        if (_inv.Count != 0)
        {
            foreach (var resources in _inv.Keys)
            {
                var _image = Instantiate(itemPrefab, gridResources);
                _image.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/{resources}");
               // _image.GetComponent<Button>().onClick.AddListener(() => ShowItemDescription(resources));

            }
        }

    }
}
