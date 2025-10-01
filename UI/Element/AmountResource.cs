using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmountResource : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI amount;

    public void SetParams(ResourceAmount res)
    {
        icon.sprite = res.resource.icon;
        amount.text = res.amount.ToString();
    }
}