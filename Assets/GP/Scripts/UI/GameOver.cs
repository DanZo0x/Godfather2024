using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button _returnButton;
    [SerializeField] private GameObject defaultSelectedButton; // Le bouton par d�faut � s�lectionner quand le menu pause est affich�
    
    void Start()
    {
        defaultSelectedButton = _returnButton.gameObject;
        EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
    }
        
}
