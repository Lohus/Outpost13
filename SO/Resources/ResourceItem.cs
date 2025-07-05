using UnityEngine;

[CreateAssetMenu(fileName = "NewResource", menuName = "Data/Resource")]
// Resource item that can be extract
public class ResourceItem : Item
{
    public float multiplie = 1; // Coefficient of resycle
    public string resycleRes; // Resource that be after resycle
}