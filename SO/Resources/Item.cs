using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "NewItem", menuName = "Data/Item")]
// Simple item
public class Item : ScriptableObject
{
    public string nameItem;
    public Sprite icon;
    public string description;
}