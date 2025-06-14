using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    float offset = 15;
    GameObject target;
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.transform.position + new Vector3(-offset, offset, offset);
        transform.LookAt(target.transform);
    }
}
