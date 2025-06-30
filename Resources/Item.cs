using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Data/Item")]
public class Item : ScriptableObject
{
    public string nameItem;
    public Sprite icon;
    public string description;
}