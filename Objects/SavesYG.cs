using System;
using System.Collections.Generic;
using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public Vector3 position;
        public List<ItemSave> inventory = new();
        public List<ResourceAmount> storage = new();
        public List<BuildSave> buildings = new();
        public List<string> triggerNameID = new();
        public List<string> craftItems = new();
        public bool chest = false;
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
