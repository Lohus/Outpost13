using UnityEngine;

[CreateAssetMenu(fileName = "NewSettings", menuName = "Data/Settings")]
public class SettingsGame : ScriptableObject
{
    public bool keyboardControl = true;
    public float volume = 1;
}