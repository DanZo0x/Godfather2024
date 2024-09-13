using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private float lifeTime;
    private float timer = 0;
    private Rigidbody2D rb;
    private Vector3 direction;
    [SerializeField] private bool enemy = false;
    [SerializeField] private Color flashColor = Color.yellow; // Couleur du flash
    [SerializeField] private float flashDuration = 0.1f; // Durée du flash
    private SpriteRenderer spriteRenderer; // Référence au SpriteRenderer de l'obstacle

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(float bulletSpeed, float bulletLifeTime, Vector3 target)
    {
        speed = bulletSpeed;
        lifeTime = bulletLifeTime;
        direction = target - transform.position;
        rb.velocity = direction * speed;
        StartCoroutine(FlashAndDeactivate());
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeTime) Destroy(gameObject);
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    private IEnumerator FlashAndDeactivate()
    {
        if (spriteRenderer != null && enemy)
        {
            Color originalColor = spriteRenderer.color; // Sauvegarder la couleur d'origine

            // Changer la couleur en couleur flash
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);

            // Remettre la couleur d'origine
            spriteRenderer.color = originalColor;

            yield return new WaitForSeconds(flashDuration);
            StartCoroutine(FlashAndDeactivate());
        }
    }
}
