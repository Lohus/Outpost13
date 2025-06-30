using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewResource", menuName = "Data/CraftItem")]
public class CraftItem : Item
{
    public ResourceRequire[] requirements;
}