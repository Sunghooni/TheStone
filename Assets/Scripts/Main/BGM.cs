using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    AudioSource audioSource;
    private GameObject AudioManager;
    SoundManager soundManager;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        AudioManager = GameObject.FindWithTag("AudioManager");
        soundManager = AudioManager.GetComponent<SoundManager>();
    }
    void Update()
    {
        if(audioSource.clip.name.Equals("Main_BGM"))
            audioSource.volume = soundManager.GetAudioVolume();
        else
            audioSource.volume = soundManager.GetAudioVolume() / 4;
    }
}
