using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

// Управление персонажем

public class PlayerController : MonoBehaviour
{
    public bool playerIsMove = false;
    Rigidbody playerRb;
    public Dictionary<string, int> inventory = new Dictionary<string, int> { };

    Vector3 forwardDirection;
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        forwardDirection = Vector3.forward;
        Debug.Log(inventory.Count);
    }
    void Update()
    {
        MovePLayer();
    }

    // Передвижение игрока
    void MovePLayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            forwardDirection.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            forwardDirection.x = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            forwardDirection.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            forwardDirection.z = -1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            forwardDirection = forwardDirection.normalized;
            if (forwardDirection != Vector3.zero)
                transform.forward = forwardDirection;
            playerRb.MovePosition(playerRb.position - forwardDirection * Time.deltaTime * 6);
            playerIsMove = true;
        }
        else
        {
            playerIsMove = false;
        }
    }
    // Прекращение добычи при движении игрок

}
