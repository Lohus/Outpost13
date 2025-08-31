using UnityEngine;
using UnityEngine.VFX;

public class Portal : MonoBehaviour
{
    [SerializeField] Renderer portalRenderer;
    [SerializeField] ParticleSystem[] portalEffects;


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
        foreach (var effect in portalEffects)
        {
            effect.Play();
        }
    }
}