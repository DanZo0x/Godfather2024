using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;

    //[SerializeField] DisplayObjective _displayObjective;

    private void Awake()
    {
        //_displayObjective = GetComponent<DisplayObjective>();
    }

    void Start()
    {
        _pauseMenu.SetActive(false);
    }

    private void Reset()
    {

        if (_pauseMenu == null)
        {
            _pauseMenu = GameObject.Find("SettingsMenu");
        }
    }

    public void PauseOnOff()
    {
        if (!_pauseMenu.activeSelf)
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

    }
    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        //StartCoroutine(_displayObjective.ShowObjective());

    }

}
