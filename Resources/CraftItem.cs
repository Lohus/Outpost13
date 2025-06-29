using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewResource", menuName = "Data/CraftItem")]
public class CraftItem : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string description;
    public ResourceRequire[] requirements;
}