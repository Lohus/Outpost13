// Interaction with Altar
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Localization;

public class Altar : MonoBehaviour, IInteraction
{
    [HideInInspector] public static Altar instance; // Singletone
    public UnityEvent altarActivaded; // Event if altar has been activated
    [SerializeField] GameObject goldenPaws; // Item that shows on altar
    [SerializeField] CraftItem goldenPawsItem; // Craft item
    [SerializeField] CaitMessage caitMessage; // CAIT message
    private LocalizedString activateLocal = new LocalizedString { TableReference = "Text_UI", TableEntryReference = "Activate_UI" }; // Set localization
    private GameObject buttonUse; // Button to activate the altar
    private string buttonTitle; // Text on button 
    private bool altarIsActive = false; // Altar is active
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
    // If player stay in zone actvation
    public void Interact(PlayerController player)
    {
        if (altarIsActive == false)
        {
            ShowButton();
        }
    }
    // If player left zone activation
    public void EndInteract(PlayerController player)
    {
        if (buttonUse != null) Destroy(buttonUse);
    }
    // Create button for activation
    void ShowButton()
    {
        if (buttonUse == null)
        {
            buttonUse = Interface.instance.CreateButton(buttonTitle, PressButton);
            buttonUse.GetComponent<Button>().interactable = PlayerInventory.instance.CheckItem(goldenPawsItem);
        }
    }

    // Function for button press
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