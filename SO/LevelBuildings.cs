using UnityEngine;
[System.Serializable]
// Level of buildings that can be upgrade
public class LevelBuildings
{
    public int level;
    public Sprite icon;
    public Mesh model;
    public ResourceRequire[] require;
}