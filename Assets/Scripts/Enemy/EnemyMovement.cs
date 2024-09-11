using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speedX = 0.2f;
    [SerializeField] private float speedY = 0.2f;
    [Range(0.0f, 2.5f)]
    [SerializeField] private float movementRange = 1f;
    private float initialY;

    // Start is called before the first frame update
    void Start()
    {
        initialY = Mathf.Abs(transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float newPosX = transform.position.x - speedX * Time.fixedDeltaTime;
        if (movementRange!=0 & Mathf.Abs(transform.position.y - initialY) > movementRange) speedY *= -1;
        float newPosY = transform.position.y + speedY * Time.fixedDeltaTime;

        transform.position = new Vector2(newPosX, newPosY);
    }
}
