using System.Collections.Generic;
using UnityEngine;

class PressPanel : MonoBehaviour
{
    [SerializeField] List<GameObject> lightFromTorch;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerController.instance.gameObject)
        {
            foreach (var torch in lightFromTorch)
            {
                torch.GetComponent<ParticleSystem>().Play();
                torch.GetComponent<Light>().enabled = true;
            }
        }
    }
}