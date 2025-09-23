using System.Collections.Generic;
using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public Vector3 position;
        public Dictionary<Item, int> inventory = new();
        public List<ResourceAmount> storage = new();
        public Dictionary<TypeClothes, GameObject> clothes = new();
        public Dictionary<TypeBuilding, BuildingRequire> buildings = new();
        public List<Effect> activeEffects = new();
        public List<string> triggerNameID = new();
        public bool chest = false;
    }
}
