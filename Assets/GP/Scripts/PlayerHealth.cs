using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;

    public void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneController.instance.Return();
    }
}
