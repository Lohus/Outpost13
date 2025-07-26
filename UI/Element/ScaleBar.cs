using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScaleBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameResource;
    [SerializeField] GameObject bar;
    [SerializeField] public ResycleResource resource;

    void Start()
    {
       // SetColor(resource.colorProgressbar);
        SetText(resource.name);
    }
    public void SetSize(float width)
    {
        bar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 144 * width / 100);
    }

    void SetColor(Color colorbar)
    {
        bar.GetComponent<Image>().color = colorbar;
    }
    void SetText(string name)
    {
        nameResource.text = name;
    }
}