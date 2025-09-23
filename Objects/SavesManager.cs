using UnityEngine;
using YG;

public class SavesManager : MonoBehaviour
{
    public static SavesManager instance;
    [SerializeField] SettingsGame settings;
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
            Debug.Log(YG2.saves.inventory);
            foreach (var item in YG2.saves.inventory)
            {
                if (item.Key is CraftItem craftItem) PlayerInventory.instance.AddItem(craftItem, false);
                if (item.Key is ResourceItem resourceItem) PlayerInventory.instance.AddResourcesToInvetory(resourceItem, item.Value, false);
            }
            BuildingBase[] buildings = FindObjectsOfType<BuildingBase>();

            foreach (BuildingBase build in buildings)
            {
                if (YG2.saves.buildings.ContainsKey(build.type)) build.actualLevel = YG2.saves.buildings[build.type];
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
        Debug.Log("Game Saved");
        YG2.saves.storage = TowerStorage.instance.storage;
        YG2.saves.inventory = PlayerInventory.instance.inventory;
        YG2.saves.position = PlayerController.instance.GetComponent<Transform>().position;
        YG2.saves.clothes = PlayerInventory.instance.clothes;
        YG2.saves.activeEffects = PlayerController.instance.activeEffects;
    }
    
}