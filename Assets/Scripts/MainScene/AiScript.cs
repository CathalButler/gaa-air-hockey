using UnityEngine;

/* Cathal Butler | G00346889 | Mobile Applcation Development 3 Project.
 * AiScript class. This class handles the behaviour of the AI player.
 */

public class AiScript : MonoBehaviour
{

    public float MaxMovementSpeed;
    // AI Rigidbody
    private Rigidbody2D rb;
    // AI Starting position
    private Vector2 startingPosition;

    public Rigidbody2D Puck;

    // AI Player boundary holder
    public Transform PlayerBoundaryHolder;
    // AI Player boundary
    private Boundary playerBoundary;


    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary;

    private Vector2 targetPosition;

    // Start is called before the first frame update
    private void Start()
    {
        // Setting the rigidbody to the player rigidbody
        rb = GetComponent<Rigidbody2D>();
        // Setting the starting position to the player rigidbody
        startingPosition = rb.position;

        // Setting the boundary cords of the child game objects when the game starts.
        // Used to keep the player pusher object inside the boundary.
        playerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.y,
                                        PlayerBoundaryHolder.GetChild(1).position.y,
                                        PlayerBoundaryHolder.GetChild(2).position.x,
                                        PlayerBoundaryHolder.GetChild(3).position.x);
        // Used to keep the puck object inside the boundary.
        puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y,
                                       PuckBoundaryHolder.GetChild(1).position.y,
                                       PuckBoundaryHolder.GetChild(2).position.x,
                                       PuckBoundaryHolder.GetChild(3).position.x);
    }// End start function

    private void FixedUpdate()
    {
        if (!PuckScript.WasGoal)
        {
            float movementSpeed;
            // If the puck is on the other half of the playing field, only move along the xais:
            if (Puck.position.y < puckBoundary.Down)
            {
                // Setting the movement speed randomly:
                movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
                // Setting the target position:
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, playerBoundary.Left,
                                                        playerBoundary.Right),
                                                        startingPosition.y);
            }
            else
            {
                movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, playerBoundary.Left,
                                                        playerBoundary.Right),
                                                        Mathf.Clamp(Puck.position.y, playerBoundary.Down,
                                                        playerBoundary.Up));
            }// End if else

            // Making the Ai move the distance of movement speed over the course of 1 second. 
            // This stops the AI pusher jumping stright to the puck.
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition,
                                                movementSpeed * Time.fixedDeltaTime));
        }// end if
    }// End FixedUpdate Function

    // Function the reset the position of the ai pusher:
    public void ResetPosition()
    {
        rb.position = startingPosition;
    }// End reset function
}// End class
