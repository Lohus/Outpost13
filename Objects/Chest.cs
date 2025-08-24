using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour, IInteraction
{
    [SerializeField] List<CraftItem> clothes;
    GameObject button;
    public void Interact(PlayerController player)
    {
       button = Interface.instance.CreateButton("Put Clothes", PutOnClothes);
    }
    public void EndInteract(PlayerController player)
    {
        if (button != null) Destroy(button);
    }
    void PutOnClothes()
    {
        Destroy(button);
        foreach (var cloth in clothes)
        {
            PlayerInventory.instance.PutCloth(cloth);
        }
        Destroy(GetComponent<Chest>());
    }
}