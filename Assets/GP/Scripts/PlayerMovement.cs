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
    public bool canMove = true, follow = true, Player = false;
    private Vector3 offset, destination;

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
        offset = new Vector3(transform.position.x - CameraBehaviour.instance.transform.position.x, transform.position.y - CameraBehaviour.instance.transform.position.y);
        destination = transform.position;
    }

    void FixedUpdate()
    {
        if (follow)
        {
            destination = CameraBehaviour.instance.transform.position + offset;
            destination = new Vector3(destination.x, destination.y, 0);
        }
        if (_movementVector.sqrMagnitude > 0.1f && canMove)
        {
            offset = new Vector3(transform.position.x - CameraBehaviour.instance.transform.position.x, transform.position.y - CameraBehaviour.instance.transform.position.y);
            Move();
        }
        MoveBlock();
        rb.MovePosition(destination);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _movementVector = context.ReadValue<Vector2>();
            if(Player && !GetComponent<Animator>().GetBool("isWalking")) GetComponent<Animator>().SetBool("isWalking", true);
        }
        else if (context.canceled)
        {
            _movementVector = new Vector2(0, 0);
            if (Player && GetComponent<Animator>().GetBool("isWalking")) GetComponent<Animator>().SetBool("isWalking", false);
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
        float moveY = destination.y;
        if (canMoveVertical) moveY += _movementVector.y * robotVelocity;
        float moveX = destination.x + _movementVector.x * robotVelocity;
        destination = new Vector2(moveX, moveY);
    }

    private void MoveBlock()
    {
        float moveY = destination.y;
        float moveX = destination.x; 
        if (moveX > blockCenter.transform.position.x + blockLeft) moveX = blockCenter.transform.position.x + blockLeft;
        if (moveX < blockCenter.transform.position.x + blockRight) moveX = blockCenter.transform.position.x + blockRight;
        if (moveY > blockCenter.transform.position.y + blockUp) moveY = blockCenter.transform.position.y + blockUp;
        if (moveY < blockCenter.transform.position.y + blockDown) moveY = blockCenter.transform.position.y + blockDown;
        destination = new Vector2(moveX, moveY);
    }
}
