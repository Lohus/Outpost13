using UnityEngine;
using YG;

public class SavesManager : MonoBehaviour
{
    public static SavesManager instance;
    [SerializeField] SettingsGame settings;
    [SerializeField] Database allItems;
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
    void Start()
    {
        if (settings.save == true)
        {
            TowerStorage.instance.storage = YG2.saves.storage;
            PlayerController.instance.GetComponent<Transform>().position = YG2.saves.position;
            if (YG2.saves.chest == true) Chest.instance.PutOnClothes(false);
            Debug.Log("Amount items saved: " + YG2.saves.inventory.Count);

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
            BuildingBase[] buildings = FindObjectsOfType<BuildingBase>();
            Debug.Log("Find builds: " + buildings.Length);
            Debug.Log("Amount buildings saved: " + YG2.saves.buildings.Count);
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
            YG2.SetDefaultSaves();
        }
    }
    public void Save()
    {
        YG2.saves.storage = TowerStorage.instance.storage;
        YG2.saves.position = PlayerController.instance.GetComponent<Transform>().position;
        Debug.Log("Game Saved");
        Debug.Log("Amount items saved: " + YG2.saves.inventory.Count);
        Debug.Log("Amount buildings saved: " + YG2.saves.buildings.Count);
        YG2.SaveProgress();
    }
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
}