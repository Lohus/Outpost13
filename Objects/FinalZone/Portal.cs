// Interaction with Portal
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] Renderer portalRenderer; // Shader graph
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

    // Activate sound and particle
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
    // Load final scene
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name);
            SceneManager.LoadScene("Final");
        }
    }
}