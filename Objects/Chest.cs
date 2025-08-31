using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class Chest : MonoBehaviour, IInteraction
{
    [SerializeField] List<CraftItem> clothes;
    private LocalizedString putonLocal = new LocalizedString { TableReference = "Text_UI", TableEntryReference = "PutOnClothes_UI" };
    private GameObject button;
    private string buttonTitle;
    public void Interact(PlayerController player)
    {
        button = Interface.instance.CreateButton(buttonTitle, PutOnClothes);
    }
    public void EndInteract(PlayerController player)
    {
        if (button != null) Destroy(button);
    }
    void PutOnClothes()
    {
        Destroy(button);
        foreach (var cloth in clothes)
        {
            PlayerInventory.instance.PutCloth(cloth);
        }
        Destroy(GetComponent<Chest>());
    }
    void OnEnable()
    {
        putonLocal.StringChanged += LocalizeTitle;
    }
    void OnDisable()
    {
        putonLocal.StringChanged -= LocalizeTitle;
    }
    void LocalizeTitle(string localizedText)
    {
        buttonTitle = localizedText;
    }
}