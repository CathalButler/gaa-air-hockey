using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Cathal Butler | G00346889
 * This class handles what happens when something is pressed when the user is on the main menu screen 
 */

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        //Load main game sence:
        SceneManager.LoadScene("main");

    }//End play function

    public void Quit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }//End function
}//End class
