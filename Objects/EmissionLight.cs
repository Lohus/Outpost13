// Change emission 
using System.Collections;
using UnityEngine;

class EmissionLight : MonoBehaviour
{
    [SerializeField] Light lightScene;
    [SerializeField] float emission, speed = 30f;


void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerController.instance.gameObject)
        {
            StartCoroutine(LightEqual());
        }
    }
void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerController.instance.gameObject)
        {
            StopCoroutine(LightEqual());
        }
    }

    IEnumerator LightEqual()
    {
        while (Mathf.Abs(lightScene.intensity - emission) > 0.01f)
        {
            lightScene.intensity = Mathf.Lerp(lightScene.intensity, emission, Time.deltaTime * speed);
            yield return null;
        }
        lightScene.intensity = emission;
    }
}