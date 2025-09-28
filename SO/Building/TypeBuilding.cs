using UnityEngine;
using UnityEngine.Localization;
[CreateAssetMenu(fileName = "NewBuildings", menuName = "Data/Building")]
[System.Serializable]
public class TypeBuilding : ScriptableObject
{
    public LocalizedString typeBuildings;
}