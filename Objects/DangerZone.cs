// Danger zone deals damage to player
using System.Collections;
using UnityEngine;

public class DangerZone : MonoBehaviour, IInteraction
{
    [SerializeField] Effect typeEffect; // Type effect
    Coroutine routine;
    // Player enter zone
    public void Interact(PlayerController player)
    {
        if (!player.activeEffects.Contains(typeEffect))
        {
            routine = StartCoroutine(DealingDamage(player));
        }
    }
    // Player left zone
    public void EndInteract(PlayerController player)
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }
    }
    IEnumerator DealingDamage(PlayerController player)
    {
        while (true)
        {
            player.actualHealth -= typeEffect.damage;
            yield return new WaitForSeconds(1);
        }
    }
}