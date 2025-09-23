using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class Chest : MonoBehaviour, IInteraction
{
    public static Chest instance;
    [SerializeField] List<CraftItem> clothes;
    [SerializeField] List<GameObject> tools;
    [SerializeField] CaitMessage caitMessage;
    private LocalizedString putonLocal = new LocalizedString { TableReference = "Text_UI", TableEntryReference = "PutOnClothes_UI" };
    private GameObject button;
    private string buttonTitle;
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
    public void Interact(PlayerController player)
    {
        button = Interface.instance.CreateButton(buttonTitle, () => PutOnClothes());
        button.GetComponent<Button>().onClick.AddListener(() => Interface.instance.CreateMessage(caitMessage)); // Instantita CAIT message
    }
    public void EndInteract(PlayerController player)
    {
        if (button != null) Destroy(button);
    }
    public void PutOnClothes(bool saves = true)
    {
        Destroy(button);
        foreach (var cloth in clothes)
        {
            PlayerInventory.instance.PutCloth(cloth);
        }
        PutOnTools();
        Destroy(GetComponent<Chest>());
        if (saves) SavesManager.instance.Save();
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
    void PutOnTools()
    {
        Tools.instance.tools = true;
        foreach (var tool in tools)
        {
            tool.SetActive(true);
        }
    }
}