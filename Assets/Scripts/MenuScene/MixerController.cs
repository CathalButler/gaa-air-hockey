using UnityEngine;
using UnityEngine.Audio;

/**
 * Cathal Butler | G00346889
 * This class handles the controlling of the master audio in the game. The audio mixer is assigned to the script with
 * mater channel exposing itself to allow change of volume via this script. The SetMasterAudio function is then ]
 * assigned to the volume slider in the setting page on the main menu.
 */


namespace MenuScene
{
    public class MixerController : MonoBehaviour
    {
        // Member Variables
        public AudioMixer audioMixer;
        
        public void SetMasterAudio(float volume)
        {
            audioMixer.SetFloat("volume", volume);
        }//End function
    }//End class
}//End namespace
