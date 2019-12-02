using UnityEngine;
using UnityEngine.UI;

/* Cathal Butler | G00346889 | Mobile Applcation Development 3 Project.
 * ScoreScript class. This class tracks the player and ai scores.
 */

public class ScoreScript : MonoBehaviour
{
    //Member Varaibles
    public enum Score{  AiScore, PlayerScore }
    public Text AiScoreText, PlayerScoreText;
    public UiManager uiManager;
    public int MaxScore;

    #region Scores
    private int aiScore, playerScore;
    private int AiScore
    {
        get { return aiScore; }
        set
        {
            aiScore = value;
            if (value == MaxScore) // if ai player scores 5 times the ai player wins:
                // Show restart canvas:
                uiManager.ShowRestartCanvas(true);
        }
    }// End get; set for AiScore

    private int PlayerScore 
    {
        get { return playerScore; }
        set
        {
            playerScore = value;
            if (value == MaxScore) // if the player scores 5 times the player wins:
                // Show restart canvas:
                uiManager.ShowRestartCanvas(false);
        }
    }// End get; set for PlayerScore
    #endregion

    // Function that will increment either player or ai player score if they score a goel:
    public void Increment(Score whichScore)
    {
        if (whichScore == Score.AiScore)
        {
            AiScoreText.text = (++AiScore).ToString();
        }
        else
        {
            PlayerScoreText.text = (++PlayerScore).ToString();
        }// End if else
    }//End incerement funtion

    // Function to reset the scores of both ai and player:
    public void ResetScores()
    {
        //Reset AI and Player scores to 0;
        AiScore = PlayerScore = 0;
        AiScoreText.text = PlayerScoreText.text = "0";
    }//End Reset Score function
}// End class
