using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MixerController : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMasterAudio(float volume)
    {
        audioMixer.SetFloat("MyExposedParam", volume);
    }
}
