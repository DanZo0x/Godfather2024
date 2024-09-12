using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanonMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;

    [SerializeField] private float reloadTime = 1.0f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 1.0f;
    [SerializeField] private float bulletLifeTime = 10.0f;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = direction;
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (timer > reloadTime && context.performed)
        {
            timer = 0f;

            GameObject newBullet = Instantiate(bullet);
            newBullet.GetComponent<Bullet>().Init(bulletSpeed, bulletLifeTime, target.position);
            newBullet.transform.position = transform.position;
        }
    }
}
