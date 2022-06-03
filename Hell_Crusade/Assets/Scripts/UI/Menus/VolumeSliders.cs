using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSliders : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMasterVolume (float volume)
    {
        audioMixer.SetFloat("Volume Master", volume);
    }

    public void SetMusicVolume (float volume)
    {
        audioMixer.SetFloat("Volume Music", volume);
    }

    public void SetSFXVolume (float volume)
    {
        audioMixer.SetFloat("Volume SFX", volume);
    }
}
