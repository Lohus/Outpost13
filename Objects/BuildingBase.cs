using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
// Building that can be upgrade
public class BuildingBase : MonoBehaviour
{
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
        }
    }
}