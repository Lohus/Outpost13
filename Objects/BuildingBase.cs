using System.Collections.Generic;
using UnityEngine;
// Building that can be upgrade
public class BuildingBase : MonoBehaviour
{
    public int actualLevel = 0;
    public string nameBuilding;
    public List<LevelBuildings> chainUpgrade;
    public void LevelUP(LevelBuildings building)
    {
        if (TowerStorage.instance.HashResources(building.require))
        {
            TowerStorage.instance.TakeResources(building.require);
            gameObject.GetComponent<MeshFilter>().mesh = building.model;
            actualLevel += 1;
        }
    }
}