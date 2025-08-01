using UnityEngine;
[CreateAssetMenu(fileName = "NewResycleResource", menuName = "Data/ResycleResource")]
// Resource after resycle resource
public class RecycleResource : ScriptableObject
{
    public string typeResource; // Type resource after resycle
    public Sprite icon; // Color of progressbar in tower resycle
}