using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchMusic : MonoBehaviour
{
    [SerializeField] private AudioClip LevelMusic;

    // Start is called before the first frame update
    public void Awake()
    {
        AudioManager.Instance.musicSource.clip = LevelMusic;
        PlayMusic();
    }

    public void PlayMusic()
    {
        AudioManager.Instance.musicSource.loop = true;
        AudioManager.Instance.musicSource.Play();
    }
}
