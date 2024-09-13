using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Animator _transitionAnim;
    public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Return()
    {
        //AudioManager.Instance.PlaySfx("Retour");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
        //AudioManager.Instance.PlayMusic("MainMenuMusic");
    }

    public static void LoadLevel(string nameScene)
    {
        Debug.Log(instance);
        instance.StartCoroutine(instance.LoadLevelRoutine(0,nameScene));
        
    }
    IEnumerator LoadLevelRoutine(int levelIndex = 0, string name = null)
    {
        _transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        if(levelIndex == 0)
        {
            SceneManager.LoadScene(name);
        }
        else
        {
            SceneManager.LoadScene(levelIndex);
        }
        _transitionAnim.SetTrigger("End");
    }

    public void Quit()
    {
        Application.Quit();
    }

}