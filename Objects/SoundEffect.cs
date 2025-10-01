// Custom audio source
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffect : MonoBehaviour
{
    private Transform listener; // Player position
    [SerializeField] float maxDistance = 50f;
    [SerializeField] AnimationCurve volumeCurve = AnimationCurve.Linear(0, 1, 50, 0);
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        listener = PlayerController.instance.GetComponent<Transform>();
        audioSource.spatialBlend = 0f; 
        audioSource.rolloffMode = AudioRolloffMode.Custom;
        audioSource.minDistance = 0f;
        audioSource.maxDistance = maxDistance;
    }
    // Change volume from distance to player
    void Update()
    {
        if (listener == null) return;
        float distance = Vector3.Distance(listener.position, transform.position);
        float t = Mathf.Clamp01(distance / maxDistance);
        audioSource.volume = volumeCurve.Evaluate(distance);
    }
}
