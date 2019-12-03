using UnityEngine;

/**
 * Cathal Butler | G00346889
 * This class adapted from the link below is used to allow me randomly select a Sprite from a Sprite array
 * inside the AiScript.cs. This is part of the game design requirements.
 * https://answers.unity.com/questions/589808/choose-random-gameobject-from-array.html
 */


namespace MainScene
{
    public static class ArrayExtensions
    {
        public static T GetRandom<T>(this T[] array) {
            return array[Random.Range(0, array.Length)];
        }//End method
        
    }//End static class
}//End name space