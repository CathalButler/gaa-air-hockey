using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Cathal Butler | G00346889
 * This class handles what happens when something is pressed when the user is on the main menu screen.
 * In this case when a user picks a team it will pass the sprite object through this class to be used in the main scene
 */

namespace MenuScene
{
    public class MenuManager : MonoBehaviour
    {
        // Function to start the game and also set the name of the team they picked:
        public void Play(Sprite playerPusher)
        {
            //Set team name in a static class so it can be accessed in other scripts
            StaticSpriteClass.CrossSceneInformation = playerPusher;
            //Load main game sence:
            SceneManager.LoadScene("main");

        }//End play function

        public void Quit()
        {
            Debug.Log("QUIT!");
            Application.Quit();
        }//End function

    }//End class
}//End namespace
