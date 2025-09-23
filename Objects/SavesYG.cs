using System.Collections.Generic;
using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public Vector3 position;
        public Dictionary<Item, int> inventory;
        public List<ResourceAmount> storage;
        public Dictionary<TypeClothes, GameObject> clothes;
        public Dictionary<TypeBuilding, BuildingRequire> buildings = new();
        public List<Effect> activeEffects;
        public bool chest;
    }
}
