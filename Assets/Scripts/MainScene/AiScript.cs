using MainScene.Types;
using MenuScene;
using UnityEngine;
using UnityEngine.Serialization;

/* Cathal Butler | G00346889 | Mobile Application Development 3 Project.
 * AiScript class. This class handles the behaviour of the AI player.
 */

namespace MainScene
{
    public class AiScript : MonoBehaviour
    {
        //Member Variables
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
        
        private SpriteRenderer _spriteRenderer;
        
        public ScoreScript scoreScript;

        //Array of team sprites
        public Sprite[] teams;
        // Assigned team to aiPlayer
        private Sprite _aiTeam;

        // Start is called before the first frame update
        private void Start()
        {
            // Accessing the SpriteRenderer that is attached to the Gameobject
            _spriteRenderer = GetComponent<SpriteRenderer>();
            //Randomly select a sprite from the array of sprites
            _aiTeam = RandomTeamSelection();
            // Assign the sprite passed when loading main scene
            _spriteRenderer.sprite = _aiTeam;
            //Set the name of the ai team in the score script so it can display in the score canvas
            scoreScript.SetAiTeamName(_aiTeam.name);
            // Setting the rigidbody to the player rigidbody
            _rb = GetComponent<Rigidbody2D>();
            // Setting the starting position to the player rigidbody
            _startingPosition = _rb.position;
            // Setting the boundary cords for the movable area for the AI Player
            // Used to keep the AI player pusher object inside their the boundary.
            _playerBoundary = new Boundary(playerBoundaryHolder.GetChild(0).position.y,
                playerBoundaryHolder.GetChild(1).position.y,
                playerBoundaryHolder.GetChild(2).position.x,
                playerBoundaryHolder.GetChild(3).position.x);
            // Used to keep the puck object inside the boundary play area boundary, there boundary's holders are on all
            // sides of the ai player size.
            _puckBoundary = new Boundary(puckBoundaryHolder.GetChild(0).position.y,
                puckBoundaryHolder.GetChild(1).position.y,
                puckBoundaryHolder.GetChild(2).position.x,
                puckBoundaryHolder.GetChild(3).position.x);
        }// End start function

        private void FixedUpdate()
        {    
            //Return if a goal was scored, this stops the ai player moving when a goal is scored
            if (PuckScript.WasGoal) return;
            //Variables
            float movementSpeed;
            // If the puck is on the other half of the playing field, only move along the x-ais:
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
                // Setting the movement speed randomly:
                movementSpeed = Random.Range(maxMovementSpeed * 0.4f, maxMovementSpeed);
                // Setting the target position:
                _targetPosition = new Vector2(Mathf.Clamp(
                        puck.position.x, 
                        _playerBoundary.Left, 
                        _playerBoundary.Right),
                        Mathf.Clamp(puck.position.y, _playerBoundary.Down,
                        _playerBoundary.Up));
            } // End if else

            // Making the Ai move the distance of movement speed over the course of 1 second. 
            // This stops the AI pusher jumping straight to the puck
            _rb.MovePosition(Vector2.MoveTowards(_rb.position, _targetPosition,
                movementSpeed * Time.fixedDeltaTime));
        }// End FixedUpdate Function

        // Function the reset the position of the ai pusher:
        public void ResetPosition()
        {
            _rb.position = _startingPosition;
        }// End reset function

        // This function is used to select a random team from the Sprite array with the help of the StaticArrayExtensions.cs
        // class. If the Sprite that got randomly selected matches the players sprite that they picked when they started the
        // game, it will run again to pick anything one.
        private Sprite RandomTeamSelection()
        {
            //Variables
            var temp = teams.GetRandom();
            
            // if the sprite randomly selected matches the one the player picked run again:
            if (temp != StaticSpriteClass.CrossSceneInformation) return temp;
            temp = teams.GetRandom();
            return temp;
        }//End function
    }//End class
}// End namespace