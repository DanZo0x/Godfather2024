using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Space]
    [Header("Audio Clips")]
    public AudioClip menuMusic;
    public AudioClip clickOnButton;
    
    [Space]
    [Header("Audio References")]
    [SerializeField] private AudioMixer gameMixer;
    public static AudioManager Instance;
    public GameObject musicSourceObj;
    public GameObject sfxSourceObj;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        musicSourceObj = GameObject.FindGameObjectWithTag("MusicSource");
        sfxSourceObj = GameObject.FindGameObjectWithTag("SfxSource");
        musicSource = musicSourceObj.GetComponent<AudioSource>();
        sfxSource = sfxSourceObj.GetComponent<AudioSource>();
    }

    /*void Start()
    {
        musicSource.clip = menuMusic;
        musicSource.Play();
    }*/

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
