using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public enum Score
    {
        AiScore, PlayerScore
    }

    public Text AiScoreText, PlayerScoreText;
    private int aiScore, playerScore;

    public void Increment(Score whichScore)
    {
        if (whichScore == Score.AiScore)
        {
            AiScoreText.text = (++aiScore).ToString();
        }
        else
        {
            PlayerScoreText.text = (++playerScore).ToString();
        }// End if else
    }//End incerement funtion

}// End class
