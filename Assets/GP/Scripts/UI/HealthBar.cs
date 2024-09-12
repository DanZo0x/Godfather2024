using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject[] _pv;
    [SerializeField] private Color flashColor = Color.white; // Couleur du flash
    [SerializeField] private float flashDuration = 0.1f; // Durée du flash

    private void Awake()
    {
        _pv = new GameObject[transform.childCount];

        for (int i = 0; i < _pv.Length; i++)
        {
            _pv[i] = transform.GetChild(i).gameObject;
        }
    }

    public void updatelife(int vie)
    {
        for (int i = 0; i < _pv.Length; i++)
        {
            if (i < vie)
            {
                _pv[i].SetActive(true);
            }
            else
            {
                StartCoroutine(FlashAndDeactivate(_pv[i]));
            }
        }
    }

    private IEnumerator FlashAndDeactivate(GameObject obj)
    {
        Image image = obj.GetComponentInChildren<Image>(); // On récupère le composant Image

        if (image != null)
        {
            Color originalColor = image.color; // Sauvegarder la couleur d'origine

            // Changer la couleur en couleur flash
            image.color = flashColor;

            // Attendre un court instant
            yield return new WaitForSeconds(flashDuration);

            // Remettre la couleur d'origine
            image.color = originalColor;

            // Désactiver l'objet
            obj.SetActive(false);
        }
    }
}
