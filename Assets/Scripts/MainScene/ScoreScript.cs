using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/* Cathal Butler | G00346889 | Mobile Application Development 3 Project.
 * ScoreScript class. This class tracks the player and ai scores as well as set the team names beside the scores.
 */

namespace MainScene
{
    public class ScoreScript : MonoBehaviour
    {
        //Member Variables
        public enum Score{  AiScore, PlayerScore }
        // Player and ai score text objects that are in the in-game canvas. Used to update score 
        [FormerlySerializedAs("AiScoreText")] public Text aiScoreText;
        [FormerlySerializedAs("PlayerScoreText")] public Text playerScoreText;
        // PLayer and ai team text objects that are in the in-game canvas. Used to set the team names beside the scores
        public Text aiTeamNameText;
        public Text playerTeamNameText;
        //UiManager to add the scene manager too
        public UiManager uiManager;
        //Set max score amount to allow the total amount of goals for needed to be scored before the game ends
        [FormerlySerializedAs("MaxScore")] public int maxScore;

        #region Scores
        private int _aiScore, _playerScore;
        private int AiScore
        {
            get { return _aiScore; }
            set
            {
                _aiScore = value;
                if (value == maxScore) // if ai player scores 5 times the ai player wins:
                    // Show restart canvas:
                    uiManager.ShowRestartCanvas(true);
            }
        }// End get; set for AiScore

        private int PlayerScore 
        {
            get { return _playerScore; }
            set
            {
                _playerScore = value;
                if (value == maxScore) // if the player scores 5 times the player wins:
                    // Show restart canvas:
                    uiManager.ShowRestartCanvas(false);
            }
        }// End get; set for PlayerScore
        #endregion

        // Function that will increment either player or ai player score if they score a goal:
        public void Increment(Score whichScore)
        {
            if (whichScore == Score.AiScore)
            {
                aiScoreText.text = (++AiScore).ToString();
            }
            else
            {
                playerScoreText.text = (++PlayerScore).ToString();
            }// End if else
        }//End increment function

        // Function to reset the scores of both ai and player:
        public void ResetScores()
        {
            //Reset AI and Player scores to 0;
            AiScore = PlayerScore = 0;
            aiScoreText.text = playerScoreText.text = "0";
        }//End Reset Score function

        public void SetPlayerTeamName(string playerTeamName)
        {
            playerTeamNameText.text = playerTeamName;
        }//End function

        public void SetAiTeamName(string aiTeamName)
        {
            aiTeamNameText.text = aiTeamName;
        }//End function
    }//End class
}// End namespace
