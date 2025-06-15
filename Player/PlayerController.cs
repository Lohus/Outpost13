
using System.Collections.Generic;
using UnityEngine;

// Управление персонажем

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public bool playerIsMove = false;
    Rigidbody playerRb;
    public Dictionary<ResourceItem, int> inventory = new Dictionary<ResourceItem, int> { };

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
    }
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        forwardDirection = Vector3.forward;
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
    // Rotate player to some object
    public void RotateTo(Transform objectTransform)
    {
        Vector3 forwardToObj = (gameObject.transform.position - objectTransform.position);
        forwardToObj.y = 0f;
        gameObject.transform.forward = forwardToObj;
    }

}
