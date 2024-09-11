using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsacle : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int health;

    void Start()
    {
        health = Random.Range(1, maxHealth + 1);
    }

    public void TakeDamage()
    {
        health -= 1;
        if (health <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
