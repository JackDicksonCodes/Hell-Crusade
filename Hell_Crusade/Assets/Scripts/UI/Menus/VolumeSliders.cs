using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliders : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeMaster;
    public Slider volumeMusic;
    public Slider volumeSFX;


    public void Start(){
        audioMixer.GetFloat("Volume Master", out float valueMaster);
        volumeMaster.value = valueMaster;
        audioMixer.GetFloat("Volume Master", out float valueMusic);
        volumeMusic.value = valueMusic;
        audioMixer.GetFloat("Volume Master", out float valueSFX);
        volumeMaster.value = valueSFX;
    }

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
