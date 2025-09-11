using System;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "NewStoryMessage", menuName = "Data/StoryMessage")]

public class CaitMessage : ScriptableObject
{
    public Sprite icon;
    public LocalizedString message;
}