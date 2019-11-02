using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    //Member Variables
    public ScoreScript ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }

    //Function to detect when a goal has been scored by either the AI Player or player:
    // Text on canves is updated if a goel is scored.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            // If ai scores,Increment the score by 1 then reset the position of the puck
            if (other.tag == "AiGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
                WasGoal = true;
                StartCoroutine(ResetPuck());
            }
            // If Player scores,Increment the score by 1 then reset the position of the puck
            else if (other.tag == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
                WasGoal = true;
                StartCoroutine(ResetPuck());
            }// end if, else if
        }// End if
    }// ENd OnTriggerEnter2D function

    //Function the reset the pucks position and velocity after a goal has been scored:
    private IEnumerator ResetPuck()
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);
    }// End ResetPuck function
}// End class