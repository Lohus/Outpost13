using UnityEngine;
using UnityEngine.Events;

public class StoryTrigger : MonoBehaviour
{
    public enum TriggerType { OnTriggerEnter, OnTriggerExit }
    public enum TypeMessage { OnlyMessage, ItemExist, ItemNotExist }
    [SerializeField] bool destroyObject = false;
    [SerializeField] CaitMessage caitMessage;
    [SerializeField] Item item;
    [SerializeField] TriggerType triggerType = TriggerType.OnTriggerEnter;
    [SerializeField] TypeMessage typeMessage = TypeMessage.OnlyMessage;
    delegate bool TriggerMessage();
    TriggerMessage triggerMessage;
    void Start()
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
            if(triggerMessage()) Destroy(destroyObject ? gameObject : this);
        }
    }

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