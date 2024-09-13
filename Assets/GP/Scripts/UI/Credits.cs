using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public Button _returnButton;

    [SerializeField] private GameObject defaultSelectedButton; // Le bouton par défaut à sélectionner quand le menu pause est affiché

    void Start()
    {

        //defaultSelectedButton = _returnButton.gameObject;
        EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits");
        //AudioManager.Instance.PlaySfx("Confirmer");*/
    }

}
