using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _transitionAnim;

    public InputField _inputField;
    public Button _startButton;
    public Button _quitButton;
    public Button _creditsButton;

    [SerializeField] private GameObject defaultSelectedButton;

    private void Start()
    {
        defaultSelectedButton = _inputField.gameObject;
        EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
    }

    public void UsernameSubmited()
    {
        defaultSelectedButton = _startButton.gameObject;
        EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
    }


    public void LoadNextLevel()
    {
        //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        _transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(levelIndex);
        _transitionAnim.SetTrigger("End");
    }
    
    public void Quit()
    {
#if UNITY_EDITOR //dans l'editeur
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();// en jeu
#endif
    }
}
