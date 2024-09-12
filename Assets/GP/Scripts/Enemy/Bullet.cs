using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private float lifeTime;
    private float timer = 0;
    private Rigidbody2D rb;
    private Vector3 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(float bulletSpeed, float bulletLifeTime, Vector3 target)
    {
        speed = bulletSpeed;
        lifeTime = bulletLifeTime;
        direction = transform.position - target;
        rb.velocity = direction * speed;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeTime) Destroy(gameObject);
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
