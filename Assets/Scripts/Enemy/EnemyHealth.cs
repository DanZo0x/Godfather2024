using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private bool shield = false;

    public void TakeDamage()
    {
        if (shield)
        {
            shield = false;
        }
        else
        {
            health -= 1;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
