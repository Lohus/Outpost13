using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] Renderer portalRenderer;
    [SerializeField] ParticleSystem[] portalEffects;
    [SerializeField] AudioSource audioSource;


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
        audioSource.Play();
        portalRenderer.material.SetFloat("_Enable", 1);
        foreach (var effect in portalEffects)
        {
            effect.Play();
        }
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Final");
    }
}