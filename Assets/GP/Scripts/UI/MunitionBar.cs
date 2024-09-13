using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MunitionBar : MonoBehaviour
{
    [SerializeField] private GameObject[] _munition;
    [SerializeField] private Color flashColor = Color.yellow; // Couleur du flash
    [SerializeField] private float flashDuration = 0.1f; // Dur�e du flash

    private void Awake()
    {
        _munition = new GameObject[transform.childCount];

        for (int i = 0; i < _munition.Length; i++)
        {
            _munition[i] = transform.GetChild(i).gameObject;
        }
    }

    public void updateMunition(int vie)
    {
        for (int i = 0; i < _munition.Length; i++)
        {
            if (i < vie)
            {
                _munition[i].SetActive(true);
            }
            else
            {
                StartCoroutine(FlashAndDeactivate(_munition[i]));
            }
        }
    }

    private IEnumerator FlashAndDeactivate(GameObject obj)
    {
        Image image = obj.GetComponentInChildren<Image>(); // On r�cup�re le composant Image

        if (image != null)
        {
            Color originalColor = image.color; // Sauvegarder la couleur d'origine

            // Changer la couleur en couleur flash
            image.color = flashColor;

            // Attendre un court instant
            yield return new WaitForSeconds(flashDuration);

            // Remettre la couleur d'origine
            image.color = originalColor;

            // D�sactiver l'objet
            obj.SetActive(false);
        }
    }
}
