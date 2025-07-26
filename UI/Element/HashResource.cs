using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class HashResources : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI hash;

    public void SetParams(ResourceRequire res)
    {
        icon.sprite = res.resource.icon;
        float _amount = TowerStorage.instance.AmountOfResource(res.resource);
        if (_amount >= res.amount)
        {
            hash.color = new Color32(81, 205, 81, 255);
        }
        else
        {
            hash.color = new Color32(205, 81, 81, 255);
        }
        hash.text = $"{_amount}/{res.amount}";
    }
}