using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Cathal Butler | G00346889 | Mobile Applcation Development 3 Project.
 * PuckScript class. This class handles the bahaviour of the puck on the field.
 * OnTrigger events will detect when the puck enters the goels Collider2D and that will increment
 * either player or ai player score.
 */

public class PuckScript : MonoBehaviour
{
    //Member Variables
    public ScoreScript ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rb;
    public float maxSpeed;

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
                StartCoroutine(ResetPuck(false));
            }
            // If Player scores,Increment the score by 1 then reset the position of the puck
            else if (other.tag == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(true));
            }// end if, else if
        }// End if
    }// ENd OnTriggerEnter2D function

    //Function the reset the pucks position and velocity after a goal has been scored:
    private IEnumerator ResetPuck(bool didPlayerScore)
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        // Reset veloctiy and position to 0
        rb.velocity = rb.position = new Vector2(0, 0);

        if(didPlayerScore)
        {
            // Spawn the puck on the AI side of the field
            rb.position = new Vector2(0, 1);
        }else
        {
            // Else Spawn on the player side of the field
            rb.position = new Vector2(0, -1);
        }
    }// End ResetPuck function

    public void RecenterPuck()
    {
        //Reset puck to the center of the field:
        rb.position = new Vector2(0,0);
    }// End function

    private void FixedUpdate()
    {
        // Update the velocity:
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }// End function
}// End class