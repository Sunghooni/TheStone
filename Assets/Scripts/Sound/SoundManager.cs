using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] AudioClips;

    public AudioClip GetAudioClip(string name)
    {
        AudioClip returnClip = null;

        foreach(AudioClip clip in AudioClips)
        {
            if(clip.name.Equals(name))
            {
                returnClip = clip;
                break;
            }
        }
        return returnClip;
    }

    public float GetAudioVolume()
    {
        return SaveData.Get_Volume();
    }

    public void PlaySound(GameObject obj, string clipName)
    {
        foreach(AudioClip clip in AudioClips)
        {
            if(clip.name.Equals(clipName))
            {
                obj.GetComponent<AudioSource>().volume = GetAudioVolume();
                obj.GetComponent<AudioSource>().clip = clip;
                obj.GetComponent<AudioSource>().Play();
            }
        }
    }
}
