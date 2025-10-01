// Cait message
using UnityEngine;
using YG;

public class StoryTrigger : MonoBehaviour
{
    public enum TriggerType { OnTriggerEnter, OnTriggerExit }
    public enum TypeMessage { OnlyMessage, ItemExist, ItemNotExist }
    public string nameID; // Unique name 
    [SerializeField] bool destroyObject = false;
    [SerializeField] CaitMessage caitMessage; // Message
    [SerializeField] Item item; // Item for activate trigger
    [SerializeField] TriggerType triggerType = TriggerType.OnTriggerEnter;
    [SerializeField] TypeMessage typeMessage = TypeMessage.OnlyMessage;
    delegate bool TriggerMessage();
    TriggerMessage triggerMessage;
    void Awake()
    {
        switch (typeMessage)
        {
            case TypeMessage.OnlyMessage:
                triggerMessage = CreateMessage;
                break;
            case TypeMessage.ItemExist:
                triggerMessage = ItemExist;
                break;
            case TypeMessage.ItemNotExist:
                triggerMessage = ItemNotExist;
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (triggerType == TriggerType.OnTriggerEnter)
        {
            InvokeMessage(other);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (triggerType == TriggerType.OnTriggerExit)
        {
            InvokeMessage(other);
        }
    }
    void InvokeMessage(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (triggerMessage())
            {
                Debug.Log("Before save");
                if (!YG2.saves.triggerNameID.Contains(this.nameID))
                {
                    YG2.saves.triggerNameID.Add(this.nameID);
                    Debug.Log("Save trigger: " + this.nameID);
                    SavesManager.instance.Save();
                }
                Destroy(destroyObject ? gameObject : this);
            }

        }
    }
    // If item in player inventory
    bool ItemExist()
    {
        if (PlayerInventory.instance.CheckItem(item))
        {
            return CreateMessage();
        }
        else
        {
            return false;
        }
    }
    // If item not in player inventory
    bool ItemNotExist()
    {
        if (!PlayerInventory.instance.CheckItem(item))
        {
            return CreateMessage();
        }
        else
        {
            return true;
        }
    }
    bool CreateMessage()
    {
        Interface.instance.CreateMessage(caitMessage);
        return true;
    }
}