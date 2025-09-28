using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "NewItem", menuName = "Data/Item")]
// Simple item
[System.Serializable]
public class Item : ScriptableObject
{
    public LocalizedString nameItem;
    public Sprite icon;
    public LocalizedString description;
}