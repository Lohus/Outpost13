using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Renderer portalRenderer;


    void Start()
    {
        Altar.instance.altarActivaded.AddListener(EnableEffects);
    }
    void OnDisable()
    {
        Altar.instance.altarActivaded.RemoveListener(EnableEffects);
    }

    void EnableEffects()
    {
       portalRenderer.material.SetFloat("_Enable", 1);
    }
}