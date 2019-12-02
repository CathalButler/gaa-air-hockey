using UnityEngine;
using UnityEngine.Audio;

namespace MenuScene
{
    public class MixerController : MonoBehaviour
    {
        public AudioMixer audioMixer;

        public void SetMasterAudio(float volume)
        {
            audioMixer.SetFloat("MyExposedParam", volume);
        }
    }
}
