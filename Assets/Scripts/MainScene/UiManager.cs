using UnityEngine;
using UnityEngine.SceneManagement;

/* Cathal Butler | G00346889 | Mobile Applcation Development 3 Project.
 * UiManager class. This class handles the behaviour of the game canvas and restart canvas.
 */

public class UiManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject GameCanvas;
    public GameObject RestartCanvas;
    public GameObject PauseCanvas;

    [Header("Restart Canvas")]
    public GameObject WinText;
    public GameObject LooseText;

    [Header("Other")]
    public ScoreScript scoreScript;

    public PuckScript puckScript;
    public PlayerMovement playerMovement;
    public AiScript aiScript;


    //Function to display Restart game canvas:
    // This function is called from score script once 5 goels by either player or ai has been scored:
    public void ShowRestartCanvas(bool didAiWin)
    {
        // Freeze the game:
        Time.timeScale = 0;
        // Hide game canvas:
        GameCanvas.SetActive(false);
        // Show restart canvas:
        RestartCanvas.SetActive(true);

        if (didAiWin)
        {
            // Hide win text as player did not win, the ai did:
            WinText.SetActive(false);
            // Show loose text as player lost agents ai:
            LooseText.SetActive(true);
        }
        else
        {
            // Show win text as the player won agent the ai:
            WinText.SetActive(true);
            // Hide loose text
            LooseText.SetActive(false);
        }
    }// End function

    // Function that will display the pause canvas menu
    public void ShowPauseCanvas()
    {
        // Freeze the game:
        Time.timeScale = 0;
        // Hide game canvas:
        GameCanvas.SetActive(false);

        // Display Pause canvas
        PauseCanvas.SetActive(true);

    }//End function

    //Function that allows the game to be resumes from the pause menu 
    public void ResumeGame()
    {
        // Contiune game
        Time.timeScale = 1;
        //Display Game Canvas
        GameCanvas.SetActive(true);
        //Hide Pause Canvas
        PauseCanvas.SetActive(false);
    }//End function

    public void RestartGame()
    {
        // Unfreeze game:
        Time.timeScale = 1;

        // Show game canvas:
        GameCanvas.SetActive(true);
        // Hide Restart canvas:
        RestartCanvas.SetActive(false);
        //Hide Pasus Canvas if it was enabled 
        PauseCanvas.SetActive(false);
        //Reset scores:
        scoreScript.ResetScores();
        //Recenter the puck to the center of the field:
        puckScript.RecenterPuck();
        //Reset player and Ai positions:
        playerMovement.ResetPosition();
        aiScript.ResetPosition();


    }// End function

    //Function that will load menu scene, this will be used if the menu button is pressed in end game menu or pause menu
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("menu");
    }//End function
}//End class
