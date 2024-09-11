using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int _health = 3;
    private int _maxHealth;
    private HealthBar _healthScript;
    private Vector3 positionSpawn;

    void Start()
    {
        positionSpawn = transform.position;
        _maxHealth = _health;
        _healthScript = GameObject.FindObjectOfType<HealthBar>();
        _healthScript.updatelife(_health);
    }

    public void takeDamage(int degats)
    {
        _health = _health - degats;
        if (_health <= 0)
        {
            SceneController.instance.Return();
        }
        _healthScript.updatelife(_health);
    }

    void OnTriggerEnter2D(Collider2D truc)
    {
        
        if (truc.tag == "CheckPoint")
        {
            positionSpawn = transform.position;
        }
    }

    void respawn()
    {
        transform.position = positionSpawn;
    }
}
