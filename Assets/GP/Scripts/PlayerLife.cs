using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int _health = 10;
    private int _maxHealth;
    private HealthBar _healthScript;

    void Awake()
    {
        _maxHealth = _health;
        _healthScript = GameObject.FindObjectOfType<HealthBar>();
        _healthScript.updatelife(_health);
    }

    public void takeDamage(int degats)
    {
        _health = _health - degats;
        if (_health <= 0)
        {
            //SceneController.instance.Return();
        }
        _healthScript.updatelife(_health);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null && collider.CompareTag("Enemy"))
            takeDamage(2);
            Debug.Log("ennemy touched");

        if (collider != null && collider.CompareTag("Bullet"))
            takeDamage(1);
        Debug.Log("ennemy touched");

    }
}

