using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Localization;

public class Altar : MonoBehaviour, IInteraction
{
    [HideInInspector] public static Altar instance;
    public UnityEvent altarActivaded;
    [SerializeField] GameObject goldenPaws; // Item that shows on altar
    [SerializeField] CraftItem goldenPawsItem; // Craft item
    [SerializeField] CaitMessage caitMessage;
    private LocalizedString activateLocal = new LocalizedString { TableReference = "Text_UI", TableEntryReference = "Activate_UI" };
    private GameObject buttonUse;
    private string buttonTitle;
    private bool altarIsActive = false;
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
        if (altarIsActive == false)
        {
            ShowButton();
        }
    }
    public void EndInteract(PlayerController player)
    {
        if (buttonUse != null) Destroy(buttonUse);
    }

    void ShowButton()
    {
        buttonUse = Interface.instance.CreateButton(buttonTitle, PressButton);
        buttonUse.GetComponent<Button>().interactable = PlayerInventory.instance.CheckItem(goldenPawsItem);
    }

    void PressButton()
    {
        goldenPaws.SetActive(true);
        PlayerInventory.instance.inventory.Remove(goldenPawsItem);
        altarIsActive = true;
        altarActivaded?.Invoke();
        Interface.instance.CreateMessage(caitMessage);
        Destroy(buttonUse);
    }
    void OnEnable()
    {
        activateLocal.StringChanged += LocalizeTitle;
    }
    void OnDisable()
    {
        activateLocal.StringChanged -= LocalizeTitle;
    }
    void LocalizeTitle(string localizedText)
    {
        buttonTitle = localizedText;
    }
}