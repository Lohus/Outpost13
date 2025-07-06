using System.Collections.Generic;
using UnityEngine;
using System.Linq;
// Building that can be upgrade
public class BuildingBase : MonoBehaviour
{
    public BuildingRequire actualLevel;
    public List<LevelBuildings> chainUpgrade;
    public void LevelUP(LevelBuildings building)
    {
        if (TowerStorage.instance.HashResources(building.requireRes) && TowerStorage.instance.CheckRequireBuilding(building.requireBuild))
        {
            TowerStorage.instance.TakeResources(building.requireRes);
            gameObject.GetComponent<MeshFilter>().mesh = building.model;
            actualLevel.level += 1;
        }
    }
}