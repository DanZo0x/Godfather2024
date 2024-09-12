using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsacle : MonoBehaviour
{
    [SerializeField] private int points = 2;
    [SerializeField] private int maxHealth = 3;
    private int health;

    [SerializeField] private Color flashColor = Color.white; // Couleur du flash
    [SerializeField] private float flashDuration = 0.1f; // Durée du flash
    [SerializeField] private GameObject _building;

    void Start()
    {
        health = Random.Range(1, maxHealth + 1);
    }

    public void TakeDamage()
    {
        StartCoroutine(FlashAndDeactivate(_building));
        health -= 1;
        if (health <= 0) Die();
    }

    private void Die()
    {
        Leaderboard.instance.AddPoints(points);
        Destroy(gameObject);
    }

    private IEnumerator FlashAndDeactivate(GameObject obj)
    {
        SpriteRenderer skin = obj.GetComponent<SpriteRenderer>(); // On récupère le composant Image

        if (skin != null)
        {
            Color originalColor = skin.color; // Sauvegarder la couleur d'origine

            // Changer la couleur en couleur flash
            skin.color = flashColor;

            // Attendre un court instant
            yield return new WaitForSeconds(flashDuration);

            // Remettre la couleur d'origine
            skin.color = originalColor;

            // Désactiver l'objet
            obj.SetActive(false);
        }
    }
}
