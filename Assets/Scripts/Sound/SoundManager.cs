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

        if (returnClip == null)
            Debug.Log("AudioClip isn't Exist");

        return returnClip;
    }

    public float GetAudioVolume()
    {
        return SaveData.Get_Volume();
    }
}
