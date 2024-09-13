using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    [SerializeField] private AudioClip MenuMusic;

    // Start is called before the first frame update
    public void Awake()
    {
        AudioManager.Instance.musicSource.clip = MenuMusic;
        PlayMusic();
    }

    public void PlayMusic()
    {
        AudioManager.Instance.musicSource.loop = true;
        AudioManager.Instance.musicSource.Play();
    }
}
