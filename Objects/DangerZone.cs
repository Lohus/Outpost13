using System.Collections;
using UnityEngine;

public class DangerZone : MonoBehaviour, IInteraction
{
    [SerializeField] Effect typeEffect;
    Coroutine routine;
    public void Interact(PlayerController player)
    {
        routine = StartCoroutine(DealingDamage(player));
    }
    public void EndInteract(PlayerController player)
    {
        StopCoroutine(routine);
    }
    IEnumerator DealingDamage(PlayerController player)
    {
        while (true)
        {
            player.actualHealth -= typeEffect.damage;
            Interface.instance.UpdateHealthBar();
            yield return new WaitForSeconds(1);
        }
    }
}