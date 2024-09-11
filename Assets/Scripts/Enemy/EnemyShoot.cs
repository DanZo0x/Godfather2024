using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float shootingSpeed = 1.0f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 1.0f;
    [SerializeField] private float bulletLifeTime = 10.0f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > shootingSpeed)
        {
            Shoot();
            timer = 0f;
        }
    }

    private void Shoot()
    {
        GameObject newBullet =  Instantiate(bullet);
        newBullet.GetComponent<Bullet>().Init(bulletSpeed, bulletLifeTime);
        newBullet.transform.position = transform.position;
        newBullet.transform.eulerAngles = Vector3.left;
    }
}
