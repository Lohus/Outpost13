
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Player control

public class PlayerController : MonoBehaviour
{
    public UnityEvent playerIsMove = new UnityEvent(); // Event if player is move
    [HideInInspector] public static PlayerController instance; // Singletone
    Rigidbody playerRb;

    Vector3 forwardDirection;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        playerRb = gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {
        forwardDirection = Vector3.forward;
    }
    void Update()
    {
        MovePLayer();
    }

    // Movement player
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
            playerIsMove?.Invoke();
        }
    }
    // Rotate player to some object
    public void RotateTo(Transform objectTransform)
    {
        Vector3 forwardToObj = (gameObject.transform.position - objectTransform.position);
        forwardToObj.y = 0f;
        gameObject.transform.forward = forwardToObj;
    }

}
