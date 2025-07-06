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
        if (TowerStorage.instance.HashResources(building.requireRes) && CheckRequireBuilding(building.requireBuild))
        {
            TowerStorage.instance.TakeResources(building.requireRes);
            gameObject.GetComponent<MeshFilter>().mesh = building.model;
            actualLevel.level += 1;
        }
    }

    bool CheckRequireBuilding(BuildingRequire[] buildings)
    {
        List<BuildingRequire> _buildings = GameObject.FindGameObjectsWithTag("Building").Select(go => go.GetComponent<BuildingBase>().actualLevel).ToList();
        foreach (var requireBuild in buildings)
        {
            if (_buildings.Find(b => b.type == requireBuild.type).level != requireBuild.level)
            {
                return false;
            }
        }
        return true;
    }
}