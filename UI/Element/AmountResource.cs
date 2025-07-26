using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class AmountResource : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI amount;

    public void SetParams(Sprite image, string text)
    {
        icon.sprite = image;
        amount.text = text;
    }
}