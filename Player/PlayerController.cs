
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

// Player control

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public static PlayerController instance; // Singletone
    public UnityEvent playerIsMove = new UnityEvent(); // Event if player is move
    Rigidbody playerRb;
    Vector3 forwardDirection;
    public List<Effect> activeEffects = new();
    public float maxHealth = 20;
    public float actualHealth = 20;
    [SerializeField] float speed = 6;
    [SerializeField] public Animator animatorPlayer;
    [SerializeField] public SkinnedMeshRenderer targetBody;
    [SerializeField] VirtualJoystick joystick;
    [SerializeField] SettingsGame settings;
    [SerializeField] CaitMessage[] caitMessages;
    [SerializeField] AudioSource audioSource;

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
        AudioListener.volume = settings.volume;
    }
    void Start()
    {
        forwardDirection = Vector3.forward;
    }
    void Update()
    {
        CheckHealth();
        if (settings.keyboardControl)
        {
            MovePLayer();
        }
        else
        {
            StickControll();
        }
    }

    // Movement player
    void MovePLayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            forwardDirection.x = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            forwardDirection.x = -1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            forwardDirection.z = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            forwardDirection.z = 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            forwardDirection = forwardDirection.normalized;
            if (forwardDirection != Vector3.zero)
                transform.forward = forwardDirection;
            playerRb.MovePosition(playerRb.position + forwardDirection * Time.deltaTime * speed);
            playerIsMove?.Invoke();
            animatorPlayer.SetBool("Run", true);
            if (!audioSource.isPlaying) audioSource.Play();
        }
        else
        {
            audioSource.Stop();
            animatorPlayer.SetBool("Run", false);
        }
    }
    // Rotate player to some object
    public void RotateTo(Transform objectTransform)
    {
        Vector3 forwardToObj = (objectTransform.position - gameObject.transform.position);
        forwardToObj.y = 0f;
        gameObject.transform.forward = forwardToObj;
    }
    void OnTriggerEnter(Collider other)
    {
        IInteraction objectInteraction = other.GetComponent<IInteraction>();
        if (objectInteraction != null)
        {
            objectInteraction.Interact(this);
        }
    }
    void OnTriggerExit(Collider other)
    {
        IInteraction objectInteraction = other.GetComponent<IInteraction>();
        if (objectInteraction != null)
        {
            objectInteraction.EndInteract(this);
        }
    }

    void StickControll()
    {
        float h = -joystick.Horizontal();
        float v = -joystick.Vertical();
        forwardDirection = new Vector3(h, 0, v);
        if (forwardDirection != Vector3.zero)
        {
            transform.forward = forwardDirection;
            playerRb.MovePosition(playerRb.position + forwardDirection * Time.deltaTime * speed);
            playerIsMove?.Invoke();
            animatorPlayer.SetBool("Run", true);
        }
        else
        {
            animatorPlayer.SetBool("Run", false);
        }
        
    }
    void CheckHealth()
    {
        if (actualHealth <= 0)
        {
            Interface.instance.CreateMessage(caitMessages[Random.Range(0, caitMessages.Length)]);
            playerRb.position = new Vector3(6, 0, -4);
            actualHealth = maxHealth;
        }
    }

}
