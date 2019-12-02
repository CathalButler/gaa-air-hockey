using System.Collections;
using System.Collections.Generic;
using MainScene;
using UnityEngine;
using UnityEngine.Serialization;

/* Cathal Butler | G00346889 | Mobile Applcation Development 3 Project.
 * PuckScript class. This class handles the bahaviour of the puck on the field.
 * OnTrigger events will detect when the puck enters the goels Collider2D and that will increment
 * either player or ai player score.
 */

public class PuckScript : MonoBehaviour
{
    //Member Variables
    [FormerlySerializedAs("ScoreScriptInstance")] public ScoreScript scoreScriptInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D _rb;
    public float maxSpeed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }

    //Function to detect when a goal has been scored by either the AI Player or player:
    // Text on canves is updated if a goel is scored.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (WasGoal) return;
        switch (other.tag)
        {
            // If ai scores,Increment the score by 1 then reset the position of the puck
            // If Player scores,Increment the score by 1 then reset the position of the puck
            case "AiGoal":
                scoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(false));
                break;
            case "PlayerGoal":
                scoreScriptInstance.Increment(ScoreScript.Score.AiScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(true)); // end if, else if
                break;
        }
    }// ENd OnTriggerEnter2D function

    //Function the reset the pucks position and velocity after a goal has been scored:
    private IEnumerator ResetPuck(bool didPlayerScore)
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        // Reset veloctiy and position to 0
        _rb.velocity = _rb.position = new Vector2(0, 0);

        if(didPlayerScore)
        {
            // Spawn the puck on the AI side of the field
            _rb.position = new Vector2(0, 1);
        }else
        {
            // Else Spawn on the player side of the field
            _rb.position = new Vector2(0, -1);
        }
    }// End ResetPuck function

    public void RecenterPuck()
    {
        //Reset puck to the center of the field:
        _rb.position = new Vector2(0,0);
    }// End function

    private void FixedUpdate()
    {
        // Update the velocity:
        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, maxSpeed);
    }// End function
}// End class