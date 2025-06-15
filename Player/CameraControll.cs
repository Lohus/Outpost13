using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    float offset = 15;
    Transform target;
    void Start()
    {
        target = PlayerController.instance.GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + new Vector3(-offset, offset, offset);
        transform.LookAt(target);
    }
}
