using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseOnButton;

    //[SerializeField] DisplayObjective _displayObjective;

    private void Awake()
    {
        //_displayObjective = GetComponent<DisplayObjective>();
    }

    void Start()
    {
        PauseOff();
        _pauseMenu.SetActive(false);
        _pauseOnButton.SetActive(true);


    }

    private void Reset()
    {
        if (_pauseOnButton == null)
        {
            _pauseOnButton = GameObject.Find("SettingsOnBtn");
        }

        if (_pauseMenu == null)
        {
            _pauseMenu = GameObject.Find("SettingsMenu");
        }
    }

    public void PauseOn()
    {
        if (!_pauseMenu.activeSelf)
        {
            _pauseOnButton.SetActive(false);
            _pauseMenu.SetActive(true);
            

        }

    }

    public void PauseOff()
    {
        if (_pauseMenu.activeSelf)// si le menu est activ� on le d�sac
        {
            _pauseOnButton.SetActive(true);
            _pauseMenu.SetActive(false);
            //Time.timeScale = 1.0f;
            

        }

    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        //StartCoroutine(_displayObjective.ShowObjective());

    }

}
