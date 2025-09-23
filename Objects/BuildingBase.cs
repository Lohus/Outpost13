using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using YG;
// Building that can be upgrade
public class BuildingBase : MonoBehaviour
{
    public TypeBuilding type;
    public BuildingRequire actualLevel;
    public List<LevelBuildings> chainUpgrade;
    public void LevelUP(LevelBuildings building)
    {
        if (TowerStorage.instance.HashResources(building.requireRes) && TowerStorage.instance.CheckRequireBuilding(building.requireBuild))
        {
            actualLevel.level += 1;
            TowerStorage.instance.TakeResources(building.requireRes);
            if (building.model != null)
            {
                gameObject.GetComponent<MeshFilter>().mesh = building.model;
            }
            if (YG2.saves.buildings.ContainsKey(type))
            {
                YG2.saves.buildings[type] = actualLevel;
            }
            else
            {
                YG2.saves.buildings[type] = actualLevel;
            }
            YG2.SaveProgress();
        }
    }
}