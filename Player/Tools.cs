// Change tool between spine and hand
using UnityEngine;

public class Tools : MonoBehaviour
{
    [HideInInspector] public static Tools instance;
    [SerializeField] Transform slotAxe, slotPickaxe, slotRightHand, slotLeftHand;
    [HideInInspector] public string nameRes;
    public bool tools = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void AttachToHand()
    {
        if (nameRes == "Дерево" || nameRes == "Wood")
        {
            slotAxe.GetChild(0).transform.SetParent(slotRightHand.transform, false);
        }
        else
        {
            slotPickaxe.GetChild(0).transform.SetParent(slotRightHand.transform, false);
        }
    }
    public void DeattachToHand()
    {
        if (nameRes == "Дерево" || nameRes == "Wood")
        {
            slotRightHand.GetChild(0).transform.SetParent(slotAxe.transform, false);
        }
        else
        {
            slotRightHand.GetChild(0).transform.SetParent(slotPickaxe.transform, false);
        }
    }
}