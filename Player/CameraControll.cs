using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Camera movement
public class CameraControll : MonoBehaviour
{
    float offset = 15; // Offset from player
    [SerializeField] Transform target; // Player on scene
    // Find player on scene
    void Start()
    {
        if (target == null) target = PlayerController.instance.GetComponent<Transform>();
    }
    // Change camera position
    void LateUpdate()
    {
        transform.position = target.position + new Vector3(offset, offset, offset);
        transform.LookAt(target);
    }
}
