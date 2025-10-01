// Blue chest on scene
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
using YG;

public class Chest : MonoBehaviour, IInteraction
{
    public static Chest instance; // Singletone
    [SerializeField] List<CraftItem> clothes; // List of clothes that put on plater
    [SerializeField] List<GameObject> tools; // List tool that put on player
    [SerializeField] CaitMessage caitMessage; // CAIT message
    private LocalizedString putonLocal = new LocalizedString { TableReference = "Text_UI", TableEntryReference = "PutOnClothes_UI" }; // Set localize
    private GameObject button; // Put on
    private string buttonTitle; // Text on button
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Player enterned zone
    public void Interact(PlayerController player)
    {
        if (!YG2.saves.chest)
        {
            button = Interface.instance.CreateButton(buttonTitle, () => PutOnClothes());
            button.GetComponent<Button>().onClick.AddListener(() => Interface.instance.CreateMessage(caitMessage)); // Instantita CAIT message
        }
    }
    // Player left zone
    public void EndInteract(PlayerController player)
    {
        if (button != null) Destroy(button);
    }
    // Put on clothes on player
    public void PutOnClothes(bool saves = true)
    {
        Destroy(button);
        foreach (var cloth in clothes)
        {
            PlayerInventory.instance.PutCloth(cloth);
        }
        PutOnTools();
        Destroy(GetComponent<Chest>());
        if (saves)
        {
            YG2.saves.chest = true; // Save progress
            YG2.SaveProgress();
        }
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
    // Put on tools
    void PutOnTools()
    {
        Tools.instance.tools = true;
        foreach (var tool in tools)
        {
            tool.SetActive(true);
        }
    }
}