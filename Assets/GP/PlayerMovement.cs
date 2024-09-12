using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject target;
    
    [Space]
    [Header("Checks")]
    [SerializeField] private bool canMoveVertical = true;
    public bool canMove = true;

    private Vector2 _movementVector;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float robotVelocity = 1.0f;


    [Space]
    [Header("Movement Block")]
    [SerializeField] private GameObject blockCenter;
    [SerializeField] private float blockUp;
    [SerializeField] private float blockDown;
    [SerializeField] private float blockLeft;
    [SerializeField] private float blockRight;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(blockCenter.transform.position + new Vector3(0, blockUp), .2f);
        Gizmos.DrawSphere(blockCenter.transform.position + new Vector3(0, blockDown), .2f);
        Gizmos.DrawSphere(blockCenter.transform.position + new Vector3(blockLeft, 0), .2f);
        Gizmos.DrawSphere(blockCenter.transform.position + new Vector3(blockRight, 0), .2f);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(_movementVector.sqrMagnitude > 0.1f && canMove)
        {
            Move();
        }
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
            target.GetComponent<PlayerMovement>().canMove = canMove;
            canMove = !canMove;
            if (playerInput.currentActionMap == playerInput.actions.FindActionMap("Player"))
            {
                playerInput.SwitchCurrentActionMap("Drone");
            }
            else
            {
                playerInput.SwitchCurrentActionMap("Player");
            }
        }
    }

    public void Move()
    {
        float moveY = transform.position.y;
        if (canMoveVertical) moveY += _movementVector.y * robotVelocity;
        float moveX = transform.position.x + _movementVector.x * robotVelocity;
        if (moveX > blockCenter.transform.position.x + blockLeft) moveX = blockCenter.transform.position.x + blockLeft;
        if (moveX < blockCenter.transform.position.x + blockRight) moveX = blockCenter.transform.position.x + blockRight;
        if (moveY > blockCenter.transform.position.y + blockUp) moveY = blockCenter.transform.position.y + blockUp;
        if (moveY < blockCenter.transform.position.y + blockDown) moveY = blockCenter.transform.position.y + blockDown;
        Vector2 newPosVector = new Vector2(moveX, moveY);
        rb.MovePosition(newPosVector);
    }
}
