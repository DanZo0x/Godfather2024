using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;
    public Button resumeButton; // Bouton pour reprendre le jeu
    public Button backToMenuButton; // Bouton pour retourner au menu principal

    [SerializeField] private GameObject defaultSelectedButton; // Le bouton par défaut à sélectionner quand le menu pause est affiché

    void Start()
    {
        _pauseMenu.SetActive(false);
        // Assigner le bouton par défaut à sélectionner
        defaultSelectedButton = resumeButton.gameObject;
    }

    private void Reset()
    {

        if (_pauseMenu == null)
        {
            _pauseMenu = GameObject.Find("PauseMenu");
        }
    }

    public void PauseOnOff()
    {
        if (!_pauseMenu.activeSelf)
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            // Sélectionne automatiquement le bouton par défaut avec la manette
            EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
        }
        else
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;

            // Réinitialise l'objet sélectionné pour éviter les conflits quand le menu est caché
            EventSystem.current.SetSelectedGameObject(null);
        }

    }
    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

    }

    public void Resume()
    {
        if (_pauseMenu.activeSelf)
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;

            // Réinitialise l'objet sélectionné pour éviter les conflits quand le menu est caché
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

}
