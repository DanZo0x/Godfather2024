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

    private Vector2 _movementVector;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float robotVelocity = 1.0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player1 = GetComponent<BoxCollider2D>();
        playinp = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Move();
    }
    
    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _movementVector = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _movementVector = new Vector2(0, 0);
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

    public void Move()
    {
        Vector2 newPosVector = new Vector2(transform.position.x + _movementVector.x * robotVelocity, transform.position.y);
        rb.MovePosition(newPosVector);
    }
}
