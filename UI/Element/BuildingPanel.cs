using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPanel : MonoBehaviour
{
    [SerializeField] Image imageBuilding; // Item icon
    [SerializeField] TextMeshProUGUI buildingName; // Item name
    [SerializeField] Transform horizontalGrid; // Transform for prefab AmountResource
    [SerializeField] GameObject hashResource; // Prefab
    [SerializeField] TextMeshProUGUI buildingRequire; // BuildingRequire
    [SerializeField] Button buttonUpgrade; // Button for craft item
    LevelBuildings levelBuildings;
    public void SetBuild(BuildingBase building, LevelBuildings level)
    {
        levelBuildings = level;
        imageBuilding.sprite = level.icon;
        buildingName.text = $"{building.actualLevel.type.name} {level.level}";
        FillBuildingRequire(level);
        SetButtonStatus(level);
        buttonUpgrade.onClick.AddListener(() => PressButton(building, level));
        foreach (ResourceRequire res in level.requireRes)
        {
            Instantiate(hashResource, horizontalGrid).GetComponent<HashResources>().SetParams(res);
        }
        foreach (BuildingRequire build in TowerStorage.instance.ReturnRequireBuildings(level.requireBuild))
        {

        }
    }
    void SetButtonStatus(LevelBuildings level)
    {
        buttonUpgrade.interactable = TowerStorage.instance.HashResources(level.requireRes) && TowerStorage.instance.CheckRequireBuilding(level.requireBuild);
    }
    void PressButton(BuildingBase building, LevelBuildings level)
    {
        building.LevelUP(level);
        Destroy(gameObject);
    }
    void FillBuildingRequire(LevelBuildings level)
    {
        List<BuildingRequire> buildings = TowerStorage.instance.ReturnRequireBuildings(level.requireBuild);
        if (buildings.Count == 0)
        {
            buildingRequire.color = new Color32(81, 205, 81, 255);
            buildingRequire.text = "All buildings is exist";
        }
        else
        {
            buildingRequire.color = new Color32(205, 81, 81, 255);
            buildingRequire.text = " ";
            foreach (BuildingRequire build in buildings)
            {
                buildingRequire.text += $"{build.type.name} {build.level} level not exist!\n"; ;

            }
        }
    }
    void OnEnable()
    {
        TowerStorage.instance.changeRes.AddListener(() => SetButtonStatus(levelBuildings));
        TowerStorage.instance.changeRes.AddListener(() => FillBuildingRequire(levelBuildings));
    }
    void OnDisable()
    {
        TowerStorage.instance.changeRes.RemoveListener(() => SetButtonStatus(levelBuildings));
        TowerStorage.instance.changeRes.RemoveListener(() => FillBuildingRequire(levelBuildings));
    }
}