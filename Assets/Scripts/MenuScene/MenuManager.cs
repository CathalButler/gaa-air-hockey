using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Cathal Butler | G00346889
 * This class handles what happens when something is pressed when the user is on the main menu screen 
 */

namespace MenuScene
{
    public class MenuManager : MonoBehaviour
    {
        // Function to start the game and also set the name of the team they picked:
        public void Play(string playerTeam)
        {
            //Set team name in a static class so it can be accessed in other scripts
            StaticClass.CrossSceneInformation = playerTeam;
            //Load main game sence:
            SceneManager.LoadScene("main");

        }//End play function

        public void Quit()
        {
            Debug.Log("QUIT!");
            Application.Quit();
        }//End function


    }
}//End class
