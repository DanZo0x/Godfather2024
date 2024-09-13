using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float reloadTime = 1.0f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 1.0f;
    [SerializeField] private float bulletLifeTime = 10.0f;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > reloadTime)
        {
            Shoot();
            timer = 0f;
        }
    }

    private void Shoot()
    {
        //AudioManagerSingleton.Instance.TirAlt.Play();
        GameObject newBullet =  Instantiate(bullet);
        newBullet.GetComponent<Bullet>().Init(bulletSpeed, bulletLifeTime, -transform.right);
        newBullet.transform.position = transform.position;
        newBullet.transform.eulerAngles = Vector3.left;
    }
}
