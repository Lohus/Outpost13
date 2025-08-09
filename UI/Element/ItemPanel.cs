using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour
{
    [SerializeField] Image imageItem; // Item icon
    [SerializeField] TextMeshProUGUI itemName; // Item name
    [SerializeField] Transform horizontalGrid; // Transform for prefab AmountResource
    [SerializeField] GameObject hashResource; // Prefab
    [SerializeField] TextMeshProUGUI itemDescription; // Item description
    [SerializeField] Button buttonCraft; // Button for craft item
    public void SetItem(CraftItem item)
    {
        imageItem.sprite = item.icon;
        item.nameItem.StringChanged += (text) => { itemName.text = text; };
        item.description.StringChanged += (text) => { itemDescription.text = text; };
        buttonCraft.interactable = TowerStorage.instance.HashResources(item.requirements);
        buttonCraft.onClick.AddListener(() => PressButton(item));
        foreach (ResourceRequire res in item.requirements)
        {
            Instantiate(hashResource, horizontalGrid).GetComponent<HashResources>().SetParams(res);
        }
    }

    void PressButton(CraftItem item)
    {
        TowerStorage.instance.CraftItem(item);
        Destroy(gameObject);
    }
}