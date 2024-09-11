using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private float lifeTime;
    private float timer = 0;

    public void Init(float bulletSpeed, float bulletLifeTime)
    {
        speed = bulletSpeed;
        lifeTime = bulletLifeTime;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeTime) Destroy(gameObject);
        float newPosX = transform.position.x - speed * Time.fixedDeltaTime;

        transform.position = new Vector2(newPosX, transform.position.y);
    }
}
