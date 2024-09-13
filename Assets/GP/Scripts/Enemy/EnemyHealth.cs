using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private bool shield = false;
    [SerializeField] private int points = 10;
    [SerializeField] private float forceDying = 10;
    [SerializeField] private GameObject explosion;

    public void TakeDamage()
    {
        if (shield)
        {
            shield = false;
            GetComponent<Animator>().SetTrigger("Degat");
        }
        else
        {
            health -= 1;
            if (health <= 0)
            {
                Leaderboard.instance.AddPoints(points);
                StartCoroutine(Die());
            }
        }
    }

    public IEnumerator Die()
    {
        if (!GetComponent<Rigidbody2D>())
        {
            GameObject boom = Instantiate(explosion);
            boom.transform.position = transform.position;
            Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.AddForce(Vector2.left * forceDying);
            GetComponent<EnemyMovement>().enabled = false;
            GetComponent<EnemyHealth>().enabled = false;
            GetComponent<EnemyShoot>().enabled = false;
            gameObject.tag = "Untagged";
            yield return new WaitForSeconds(0.7f);
            Destroy(boom);
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null && collider.CompareTag("Player")) 
            StartCoroutine(Die());

        if (collider != null && collider.CompareTag("Bullet"))
            TakeDamage();
    }
}
