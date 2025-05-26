using UnityEngine;

public class TreeSway : MonoBehaviour 
{
    public float swaySpeed = 1f;     // Скорость покачивания
    public float swayAmount = 0.1f;  // Амплитуда
    private Vector3 startPos;

    void Start() 
    {
        startPos = transform.position;
    }

    void Update() 
    {
        // Движение по синусоиде
        float offsetX = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        float offsetZ = Mathf.Cos(Time.time * swaySpeed * 0.7f) * swayAmount * 0.5f;
        
        transform.position = startPos + new Vector3(offsetX, 0, offsetZ);
        
        // Легкий наклон
    }
}