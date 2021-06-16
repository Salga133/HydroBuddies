using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeMenu : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetVolume(float sliderValue)
    {
        mixer.SetFloat("volume", sliderValue);
    }
    
}
