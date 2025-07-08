using UnityEngine;
[CreateAssetMenu(fileName = "NewResycleResource", menuName = "Data/ResycleResource")]
// Resource after resycle resource
public class ResycleResource : ScriptableObject
{
    public string typeResource; // Type resource after resycle
    public Color colorProgressbar; // Color of progressbar in tower resycle
}