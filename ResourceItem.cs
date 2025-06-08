using UnityEngine;

[CreateAssetMenu(fileName = "NewResource", menuName = "Data/Resource")]
public class ResourceItem : ScriptableObject
{
    public string resourceName;
    public Sprite icon;
    public string description; 
}