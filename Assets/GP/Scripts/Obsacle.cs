using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsacle : MonoBehaviour
{
    [SerializeField] private int points = 2;
    [SerializeField] private int maxHealth = 3;
    private int health;

    [SerializeField] private Color flashColor = Color.red; // Couleur du flash
    [SerializeField] private float flashDuration = 0.1f; // Dur�e du flash

    [SerializeField] private Sprite[] damageSprites; // Tableau des sprites pour chaque niveau de d�g�ts
    private SpriteRenderer spriteRenderer; // R�f�rence au SpriteRenderer de l'obstacle

    [SerializeField] private AudioClip DestroySound;

    void Start()
    {
        health = Random.Range(1, maxHealth + 1); // Initialise la sant� entre 1 et maxHealth
        spriteRenderer = GetComponent<SpriteRenderer>(); // R�cup�re le SpriteRenderer attach� � l'obstacle

        // Assure-toi que l'obstacle commence avec le sprite correspondant � sa sant� maximale
        if (damageSprites.Length > 0 && spriteRenderer != null)
        {
            spriteRenderer.sprite = damageSprites[0]; // Le sprite initial est celui correspondant � l'�tat intact
        }
        UpdateSprite();

        // Lancer cette coroutine dans la fonction TakeDamage
        //StartCoroutine(Destruction()); 
    }

    public void TakeDamage()
    {
        health -= 1;

        // Changer le sprite correspondant � l'�tat actuel de l'obstacle
        UpdateSprite();

        // Lance le flash de d�g�t
        StartCoroutine(FlashAndDeactivate());

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Leaderboard.instance.AddPoints(points);
        AudioManager.Instance.sfxSource.PlayOneShot(DestroySound);
        Destroy(gameObject);
    }

    private IEnumerator FlashAndDeactivate()
    {
        if (spriteRenderer != null)
        {
            Color originalColor = spriteRenderer.color; // Sauvegarder la couleur d'origine

            // Changer la couleur en couleur flash
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);

            // Remettre la couleur d'origine
            spriteRenderer.color = originalColor;
        }
    }

    // M�thode pour changer le sprite en fonction des d�g�ts
    private void UpdateSprite()
    {
        if (spriteRenderer != null && damageSprites.Length > 0)
        {
            // Calculer l'index du sprite en fonction des d�g�ts
            int spriteIndex = Mathf.Clamp(maxHealth - health, 0, damageSprites.Length - 1);

            // Changer le sprite en fonction de l'�tat actuel
            spriteRenderer.sprite = damageSprites[spriteIndex];
        }
    }

    // Coroutine pour infliger des d�g�ts � intervalles r�guliers
    private IEnumerator Destruction()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1); // Attend un certain temps avant de r�infliger des d�g�ts
            TakeDamage(); // Inflige des d�g�ts
        }
    }
}
