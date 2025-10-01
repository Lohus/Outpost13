// PluginYG Saves
using System;
using System.Collections.Generic;
using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public Vector3 position; // Position player
        public List<ItemSave> inventory = new(); // Player inventory
        public List<ResourceAmount> storage = new(); // Tower storage
        public List<BuildSave> buildings = new(); // Level buildings
        public List<string> triggerNameID = new(); // Triggers
        public List<string> craftItems = new(); // Craft items opened
        public bool chest = false; // Uses chest
    }
}


[Serializable]
public struct ItemSave
{
    public string itemName;
    public int amount;
    public ItemSave(string itemName, int amount)
    {
        this.itemName = itemName;
        this.amount = amount;
    }
}
[Serializable]
public struct BuildSave
{
    public string typeBuildingName;
    public int level;
    public BuildSave(string typeName, int level)
    {
        this.typeBuildingName = typeName;
        this.level = level;
    }
}
