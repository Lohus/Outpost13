using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ResourceSource"))
        {
            audioSource.Play();
        }
    }
}