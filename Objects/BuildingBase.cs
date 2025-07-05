using System.Collections.Generic;
using UnityEngine;
public class BuildingBase : MonoBehaviour
{
    public int actualLevel = 0;
    public string nameBuilding;
    public List<LevelBuildings> chainUpgrade;
    public void LevelUP(LevelBuildings building)
    {
        if (Tower.instance.HashResources(building.require))
        {
            Tower.instance.TakeResources(building.require);
            gameObject.GetComponent<MeshFilter>().mesh = building.model;
            actualLevel += 1;
        }
    }
}