using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D player1;
    [SerializeField] private PlayerInput playinp;
    
    [Space]
    [Header("Checks")]
    [SerializeField] private bool canMove = true;
    
    [Space]
    [Header("Forward Movement")]
    [SerializeField] private float speedMultiplier = 1.0f;
    [SerializeField] private float progressiveSpeedMultiplier = 1.0f;
    [SerializeField] private float slowDownFactor = 1.0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player1 = GetComponent<BoxCollider2D>();
        playinp = GetComponent<PlayerInput>();
    }

    void Update()
    {
        
    }
    
    public void OnMovementX(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
        }
    }
    
    public void OnMovementY(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
        }
    }
    
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
        }
    }
    
    public void OnPunch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
        }
    }
    
    public void OnSwitch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
        }
    }
}
