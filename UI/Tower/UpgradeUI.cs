using UnityEngine;
using System.Linq;
// Upgrade building interface
public class UpgradeUI : MonoBehaviour
{
    [SerializeField] GameObject buildingPanel; // Prefab panel where data is shown
    [SerializeField] GameObject cardWindow; // Place where create prefabPanel
    BuildingBase[] buildings; // All buildings that can be upgrade on scene
    // Find all buildings on scene and show panel
    void Start()
    {
        buildings = GameObject.FindGameObjectsWithTag("Building").Select(go => go.GetComponent<BuildingBase>()).ToArray();
        ShowUpgrade();
    }
    // Show data for every upgrade
    void ShowUpgrade()
    {
        foreach (BuildingBase building in buildings)
        {
            foreach (LevelBuildings level in building.chainUpgrade)
            {
                if (building.actualLevel.level + 1 == level.level)
                {
                    Instantiate(buildingPanel, cardWindow.transform).GetComponent<BuildingPanel>().SetBuild(building, level);
                }
            }
        }
    }
}