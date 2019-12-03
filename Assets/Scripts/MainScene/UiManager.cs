using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

/* Cathal Butler | G00346889 | Mobile Application Development 3 Project.
 * UiManager class. This class handles the behaviour of the game canvas and restart canvas.
 */

namespace MainScene
{
    public class UiManager : MonoBehaviour
    {
        [FormerlySerializedAs("GameCanvas")] [Header("Canvas")]
        public GameObject gameCanvas;
        [FormerlySerializedAs("RestartCanvas")] public GameObject restartCanvas;
        [FormerlySerializedAs("PauseCanvas")] public GameObject pauseCanvas;

        [FormerlySerializedAs("WinText")] [Header("Restart Canvas")]
        public GameObject winText;
        [FormerlySerializedAs("LooseText")] public GameObject looseText;

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
            gameCanvas.SetActive(false);
            // Show restart canvas:
            restartCanvas.SetActive(true);

            if (didAiWin)
            {
                // Hide win text as player did not win, the ai did:
                winText.SetActive(false);
                // Show loose text as player lost agents ai:
                looseText.SetActive(true);
            }
            else
            {
                // Show win text as the player won agent the ai:
                winText.SetActive(true);
                // Hide loose text
                looseText.SetActive(false);
            }
        }// End function

        // Function that will display the pause canvas menu
        public void ShowPauseCanvas()
        {
            // Freeze the game:
            Time.timeScale = 0;
            // Hide game canvas:
            gameCanvas.SetActive(false);

            // Display Pause canvas
            pauseCanvas.SetActive(true);

        }//End function

        //Function that allows the game to be resumes from the pause menu 
        public void ResumeGame()
        {
            // Continue game
            Time.timeScale = 1;
            //Display Game Canvas
            gameCanvas.SetActive(true);
            //Hide Pause Canvas
            pauseCanvas.SetActive(false);
        }//End function

        public void RestartGame()
        {
            // Unfreeze game:
            Time.timeScale = 1;

            // Show game canvas:
            gameCanvas.SetActive(true);
            // Hide Restart canvas:
            restartCanvas.SetActive(false);
            //Hide Pasus Canvas if it was enabled 
            pauseCanvas.SetActive(false);
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
}//End namespace
