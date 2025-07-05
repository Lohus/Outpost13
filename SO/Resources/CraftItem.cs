using System.Collections.Generic;
using UnityEngine;
// Item that can be craft
[CreateAssetMenu(fileName = "NewCraftItem", menuName = "Data/CraftItem")]
public class CraftItem : Item
{
    public ResourceRequire[] requirements; // Require of resource for craft
}