using UnityEngine;

// Simple wind effect
public class TreeSway : MonoBehaviour
{
    public float swaySpeed = 1f;     // Speed
    public float swayAmount = 0.1f;  // Amplitude
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move on sin
        float offsetX = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        float offsetZ = Mathf.Cos(Time.time * swaySpeed * 0.7f) * swayAmount * 0.5f;

        transform.position = startPos + new Vector3(offsetX, 0, offsetZ);

    }
}