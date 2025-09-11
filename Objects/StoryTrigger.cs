using UnityEngine;
using UnityEngine.Events;

public class StoryTrigger : MonoBehaviour
{
    [SerializeField] CaitMessage caitMessage;
    [SerializeField] bool destroyObject = false;
    [SerializeField] UnityEvent triggerIvent = new UnityEvent();
    [SerializeField] CraftItem requireIitem;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerIvent?.Invoke();
            Destroy(destroyObject ? gameObject : this);
        }
    }

    public void CheckItem(CraftItem item)
    {
        if (PlayerInventory.instance.CheckItem(item))
        {
            CreateMessage(caitMessage);
        }
    }
    public void CreateMessage(CaitMessage message) => Interface.instance.CreateMessage(message);
}