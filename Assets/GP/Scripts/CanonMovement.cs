using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CanonMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;
    [SerializeField] private float reloadMunition = 2f;
    [SerializeField] private int munitionMax = 10;
    private int munition;
    private MunitionBar munitionBar;
    [SerializeField] private float reloadTime = 1.0f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 1.0f;
    [SerializeField] private float bulletLifeTime = 10.0f;
    private float timer = 0f, timer2 = 0f;

    private void Start()
    {
        munition = munitionMax;
        munitionBar = GameObject.FindObjectOfType<MunitionBar>();
        munitionBar.updateMunition(munition);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = direction;

        if (timer2 > reloadMunition && munition < 10)
        {
            timer2 = 0f;
            munition++;
            munitionBar.updateMunition(munition);
        }
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (munition > 0 && timer > reloadTime && context.performed)
        {
            //AudioManagerSingleton.Instance.TirLaser.Play();
            timer = 0f;
            munition--;
            munitionBar.updateMunition(munition);
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.position;
            newBullet.GetComponent<Bullet>().Init(bulletSpeed, bulletLifeTime, target.position);
        }
    }
}
