using System.Collections.Generic;
using UnityEngine;
// Item that can be craft
[CreateAssetMenu(fileName = "NewCraftItem", menuName = "Data/CraftItem")]
public class CraftItem : Item, IPlayerEffect
{
    public ResourceRequire[] requirements; // Require of resource for craft
    public Effect typeEffect;
    public void Apply(PlayerController player)
    {
        player.activeEffects.Add(typeEffect);
    }
    public void Remove(PlayerController player)
    {
        player.activeEffects.Remove(typeEffect);
    }

}