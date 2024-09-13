using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int _health = 10;
    private int _maxHealth;
    private HealthBar _healthScript;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Color flashColor = Color.red; // Couleur du flash
    [SerializeField] private float flashDuration = 0.1f; // Durée du flash
    private SpriteRenderer spriteRenderer; // Référence au SpriteRenderer de l'obstacle

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _gameOverPanel.SetActive(false);
        _maxHealth = _health;
        _healthScript = GameObject.FindObjectOfType<HealthBar>();
        _healthScript.updatelife(_health);
    }

    public void takeDamage(int degats)
    {
        // Lance le flash de dégât
        StartCoroutine(FlashAndDeactivate());
        _health = _health - degats;
        if (_health <= 0)
        {
            Leaderboard.instance.Save();
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        _healthScript.updatelife(_health);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null && collider.CompareTag("Enemy"))
            takeDamage(2);

        if (collider != null && collider.CompareTag("Bullet"))
            takeDamage(1);
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
}

