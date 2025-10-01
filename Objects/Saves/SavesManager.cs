// Save and load
using UnityEngine;
using YG;

public class SavesManager : MonoBehaviour
{
    public static SavesManager instance;
    [SerializeField] SettingsGame settings;
    [SerializeField] Database allItems; // List all items in game
    [SerializeField] Database craftItems; // List of opend items
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
    // Load
    void Start()
    {
        if (settings.save == true)
        {
            TowerStorage.instance.storage = YG2.saves.storage; // Load tower storage
            PlayerController.instance.GetComponent<Transform>().position = YG2.saves.position; // Load player position
            if (YG2.saves.chest == true) Chest.instance.PutOnClothes(false); // Activate chest
            // Load opened items
            foreach (string itemName in YG2.saves.craftItems)
            {
                int index = allItems.allCraftItems.FindIndex(item => item.name == itemName);
                int indexBase = craftItems.allCraftItems.FindIndex(item => item.name == itemName);
                if (index != -1 && indexBase == -1)
                {
                    craftItems.allCraftItems.Add(allItems.allCraftItems[index]);
                }
            }
            Debug.Log("Amount items saved: " + YG2.saves.inventory.Count);
            // Load player inventory
            try
            {
                foreach (ItemSave itemSave in YG2.saves.inventory)
                {
                    foreach (Item item in allItems.allCraftItems)
                    {
                        if (itemSave.itemName == item.name)
                        {
                            if (item is ResourceItem resourceItem)
                            {
                                PlayerInventory.instance.AddResourcesToInvetory(resourceItem, itemSave.amount, false);
                            }
                            else
                            {
                                CraftItem craftItem = item as CraftItem;
                                PlayerInventory.instance.AddItem(craftItem, false);
                            }
                        }
                    }
                }
            }
            catch
            {
                Debug.Log("Сouldn't add item to inventory: ");
            }
            BuildingBase[] buildings = FindObjectsOfType<BuildingBase>(); // Find all builds on scene
            Debug.Log("Find builds: " + buildings.Length);
            Debug.Log("Amount buildings saved: " + YG2.saves.buildings.Count);
            // Change level of build
            for (int i = 0; i < YG2.saves.buildings.Count; i++)
            {
                Debug.Log("Save for " + YG2.saves.buildings[i].typeBuildingName);
                foreach (BuildingBase build in buildings)
                {
                    Debug.Log("Build " + build.type.name);
                    if (YG2.saves.buildings[i].typeBuildingName == build.type.name)
                    {
                        build.actualLevel.level = YG2.saves.buildings[i].level;
                        Debug.Log("Load build: " + YG2.saves.buildings[i].typeBuildingName);
                    }
                }
            }
            // Destroy story triggers
            StoryTrigger[] triggers = FindObjectsOfType<StoryTrigger>();
            Debug.Log("Amount triggers: " + triggers.Length + " Amount names: " + YG2.saves.triggerNameID.Count);
            foreach (StoryTrigger trigger in triggers)
            {
                if (YG2.saves.triggerNameID.Contains(trigger.nameID))
                {
                    Destroy(trigger);
                }
            }

        }
        else
        {
            YG2.SetDefaultSaves(); // Reset saves
        }
    }
    public void Save()
    {
        YG2.saves.storage = TowerStorage.instance.storage; // Save storage
        YG2.saves.position = PlayerController.instance.GetComponent<Transform>().position; // Save position
        Debug.Log("Game Saved");
        Debug.Log("Amount items saved: " + YG2.saves.inventory.Count);
        Debug.Log("Amount buildings saved: " + YG2.saves.buildings.Count);
        YG2.SaveProgress(); // Save to cloud
    }
    // Add builds and level to save
    public void AddBuildToSave(string typeBuildingName, int level)
    {
        int index = YG2.saves.buildings.FindIndex(save => save.typeBuildingName == typeBuildingName);
        if (index != -1)
        {
            YG2.saves.buildings[index] = new BuildSave(typeBuildingName, level);
        }
        else
        {
            YG2.saves.buildings.Add(new BuildSave(typeBuildingName, level));
        }
        Save();
    }
    // Add items and amount to save
    public void AddItemToSave(string itemName, int amount)
    {
        int index = YG2.saves.inventory.FindIndex(save => save.itemName == itemName);
        if (index != -1)
        {
            YG2.saves.inventory[index] = new ItemSave(itemName, amount);
        }
        else
        {
            YG2.saves.inventory.Add(new ItemSave(itemName, amount));
        }
        Save();
    }
    // Remove items from save
    public void RemoveItemToSave(string itemName)
    {
        int index = YG2.saves.inventory.FindIndex(save => save.itemName == itemName);
        if (index != -1)
        {
            YG2.saves.inventory.RemoveAt(index);
        }
        Save();
    }
}