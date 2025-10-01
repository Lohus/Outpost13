// Building that can be upgrade
using System.Collections.Generic;
using UnityEngine;

public class BuildingBase : MonoBehaviour
{
    public TypeBuilding type;
    public BuildingRequire actualLevel;
    public List<LevelBuildings> chainUpgrade;
    // Upgrade build
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
            SavesManager.instance.AddBuildToSave(type.name, actualLevel.level); // Save level
        }
    }
}