using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] private int damage = 2;
    [SerializeField] private Vector3 respawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.GetComponent<PlayerLife>())
        {
            collision.GetComponent<PlayerLife>().takeDamage(damage);

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(enemy);
            }
            foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
            {
                Destroy(obstacle);
            }
            collision.GetComponent<PlayerMovement>().ForceMove(respawn);
        }
    }
}
