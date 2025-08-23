using System.Collections.Generic;
using UnityEngine;
// Item that can be craft
[CreateAssetMenu(fileName = "NewCraftItem", menuName = "Data/CraftItem")]
public class CraftItem : Item, IPlayerEffect
{
    public ResourceRequire[] requirements; // Require of resource for craft
    public Effect typeEffect; // Type of effects
    public TypeClothes typeCloth;
    public GameObject cloth;
    public void Apply(PlayerController player) // Add effect to player
    {
        if (typeEffect != null)
        {
           player.activeEffects.Add(typeEffect); 
        }
    }
    public void Remove(PlayerController player) // Remove from player
    {
        if (player.activeEffects.Contains(typeEffect))
        {
            player.activeEffects.Remove(typeEffect);    
        }
    }
}