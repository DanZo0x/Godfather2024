using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanonMovement : MonoBehaviour
{
    [SerializeField] private Transform holder;
    [SerializeField] private Transform target;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - holder.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = holder.position + offset;
        Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = direction;
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
    }
}
