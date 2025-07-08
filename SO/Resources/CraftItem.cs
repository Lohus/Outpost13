using System.Collections.Generic;
using UnityEngine;
// Item that can be craft
[CreateAssetMenu(fileName = "NewCraftItem", menuName = "Data/CraftItem")]
public class CraftItem : Item, IPlayerEffect
{
    public ResourceRequire[] requirements; // Require of resource for craft
    public Effect typeEffect; // Type of effects
    public void Apply(PlayerController player) // Add effect to player
    {
        player.activeEffects.Add(typeEffect);
    }
    public void Remove(PlayerController player) // Remove from player
    {
        player.activeEffects.Remove(typeEffect);
    }
}