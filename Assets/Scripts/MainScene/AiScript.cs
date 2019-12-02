using Types;
using UnityEngine;
using UnityEngine.Serialization;

/* Cathal Butler | G00346889 | Mobile Applcation Development 3 Project.
 * AiScript class. This class handles the behaviour of the AI player.
 */

public class AiScript : MonoBehaviour
{

    [FormerlySerializedAs("MaxMovementSpeed")] public float maxMovementSpeed;
    // AI Rigidbody
    private Rigidbody2D _rb;
    // AI Starting position
    private Vector2 _startingPosition;

    [FormerlySerializedAs("Puck")] public Rigidbody2D puck;

    // AI Player boundary holder
    [FormerlySerializedAs("PlayerBoundaryHolder")] public Transform playerBoundaryHolder;
    // AI Player boundary
    private Boundary _playerBoundary;


    [FormerlySerializedAs("PuckBoundaryHolder")] public Transform puckBoundaryHolder;
    private Boundary _puckBoundary;

    private Vector2 _targetPosition;

    // Start is called before the first frame update
    private void Start()
    {
        // Setting the rigidbody to the player rigidbody
        _rb = GetComponent<Rigidbody2D>();
        // Setting the starting position to the player rigidbody
        _startingPosition = _rb.position;

        // Setting the boundary cords of the child game objects when the game starts.
        // Used to keep the player pusher object inside the boundary.
        _playerBoundary = new Boundary(playerBoundaryHolder.GetChild(0).position.y,
                                        playerBoundaryHolder.GetChild(1).position.y,
                                        playerBoundaryHolder.GetChild(2).position.x,
                                        playerBoundaryHolder.GetChild(3).position.x);
        // Used to keep the puck object inside the boundary.
        _puckBoundary = new Boundary(puckBoundaryHolder.GetChild(0).position.y,
                                       puckBoundaryHolder.GetChild(1).position.y,
                                       puckBoundaryHolder.GetChild(2).position.x,
                                       puckBoundaryHolder.GetChild(3).position.x);
    }// End start function

    private void FixedUpdate()
    {    
        //Return if a goal was scored
        if (PuckScript.WasGoal) return;
        
        //Variables
        float movementSpeed;
        // If the puck is on the other half of the playing field, only move along the xais:
        if (puck.position.y < _puckBoundary.Down)
        {
            // Setting the movement speed randomly:
            movementSpeed = maxMovementSpeed * Random.Range(0.1f, 0.3f);
            // Setting the target position:
            _targetPosition = new Vector2(Mathf.Clamp(puck.position.x, _playerBoundary.Left,
                    _playerBoundary.Right),
                _startingPosition.y);
        }
        else
        {
            movementSpeed = Random.Range(maxMovementSpeed * 0.4f, maxMovementSpeed);
            _targetPosition = new Vector2(Mathf.Clamp(puck.position.x, _playerBoundary.Left,
                    _playerBoundary.Right),
                Mathf.Clamp(puck.position.y, _playerBoundary.Down,
                    _playerBoundary.Up));
        }// End if else

        // Making the Ai move the distance of movement speed over the course of 1 second. 
        // This stops the AI pusher jumping stright to the puck.
        _rb.MovePosition(Vector2.MoveTowards(_rb.position, _targetPosition,
            movementSpeed * Time.fixedDeltaTime));
    }// End FixedUpdate Function

    // Function the reset the position of the ai pusher:
    public void ResetPosition()
    {
        _rb.position = _startingPosition;
    }// End reset function
}// End class
