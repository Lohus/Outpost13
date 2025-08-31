using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using System;

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
        building.actualLevel.type.typeBuildings.StringChanged += (text) => buildingName.text = $"{text} {level.level}";
        //buildingName.text = $"{building.actualLevel.type.typeBuildings} {level.level}";
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
        LocalizedString allBuilding = new LocalizedString("Text_UI", "AllBuilding_UI");
        LocalizedString specificBuilding = new LocalizedString("Text_UI", "SpecificBuilding_UI");
        List<BuildingRequire> buildings = TowerStorage.instance.ReturnRequireBuildings(level.requireBuild);
        if (buildings.Count == 0)
        {
            buildingRequire.color = new Color32(81, 205, 81, 255);
            allBuilding.StringChanged += (text) => { buildingRequire.text = text; };
        }
        else
        {
            buildingRequire.color = new Color32(205, 81, 81, 255);
            buildingRequire.text = "";
            string nameBuilding = "";
            foreach (BuildingRequire build in buildings)
            {
                build.type.typeBuildings.StringChanged += (text) =>
                {
                    nameBuilding = text;
                    specificBuilding.Arguments = new object[] { nameBuilding, build.level };
                    specificBuilding.StringChanged += (text) => { buildingRequire.text += text + "\n"; };
                };
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