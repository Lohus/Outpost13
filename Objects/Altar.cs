using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Altar : MonoBehaviour, IInteraction
{
    [HideInInspector] public static Altar instance;
    public UnityEvent altarActivaded;
    [SerializeField] GameObject goldenPaws; // Item that shows on altar
    [SerializeField] CraftItem goldenPawsItem; // Craft item
    [SerializeField] Database database;
    GameObject buttonUse;
    bool altarIsActive = false;
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
            if (!database.allCraftItems.Contains(goldenPawsItem))
            {
                database.allCraftItems.Add(goldenPawsItem);
            }
            ShowButton();
        }
    }
    public void EndInteract(PlayerController player)
    {
        if (buttonUse != null) Destroy(buttonUse);
    }

    void ShowButton()
    {
        buttonUse = Interface.instance.CreateButton("activate", PressButton);
        buttonUse.GetComponent<Button>().interactable = PlayerInventory.instance.CheckItem(goldenPawsItem);
    }

    void PressButton()
    {
        goldenPaws.SetActive(true);
        PlayerInventory.instance.inventory.Remove(goldenPawsItem);
        altarIsActive = true;
        altarActivaded?.Invoke();
        Destroy(buttonUse);
    }
}