using UnityEngine;
using YG;

public class AddToDatabase : MonoBehaviour
{
    [SerializeField] Database database;
    [SerializeField] CraftItem item;

    void OnTriggerEnter(Collider other)
    {
        if (!database.allCraftItems.Contains(item))
        {
            database.allCraftItems.Add(item);
            YG2.saves.craftItems.Add(item.name);
            SavesManager.instance.Save();
            Destroy(this);
        }
    }
}