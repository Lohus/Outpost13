using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewUpgrade", menuName = "Data/Upgrade")]
public class UpgradeBuildings : ScriptableObject
{
    public string nameBuildings;
    public List<LevelBuildings> chainUpgrade;
}