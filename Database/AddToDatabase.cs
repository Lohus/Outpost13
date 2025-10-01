// Add items to database and save in Yandex from PluginYG
using UnityEngine;
using YG;

public class AddToDatabase : MonoBehaviour
{
    [SerializeField] Database database;
    [SerializeField] CraftItem item;

    void OnTriggerEnter(Collider other)
    {
        if (!database.allCraftItems.Contains(item)) // Check item in database
        {
            database.allCraftItems.Add(item); // Add item to database
            YG2.saves.craftItems.Add(item.name); // Save item
            SavesManager.instance.Save(); // Save other parameters in Cloud
            Destroy(this); // Destroy this trigger
        }
    }
}