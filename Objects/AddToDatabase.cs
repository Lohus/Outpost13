using UnityEngine;

public class AddToDatabase : MonoBehaviour
{
    [SerializeField] Database database;
    [SerializeField] CraftItem item;

    void OnTriggerEnter(Collider other)
    {
        if (!database.allCraftItems.Contains(item))
        {
            database.allCraftItems.Add(item);
            Destroy(this);
        }
    }
}