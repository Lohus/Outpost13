using UnityEngine;

[CreateAssetMenu(fileName = "NewResource", menuName = "Data/Resource")]
// Resource item that can be extract
[System.Serializable]
public class ResourceItem : Item
{
    public float multiplie = 1; // Coefficient of resycle
    public RecycleResource resycleRes; // Resource that be after resycle
    public BuildingRequire[] buildRequire;
}