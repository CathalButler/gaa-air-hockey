﻿using MainScene.Types;
using MenuScene;
using UnityEngine;
using UnityEngine.Serialization;

/* Cathal Butler | G00346889 | Mobile Application Development 3 Project.
 * PlayerMovement class. This class handles the behaviour of how the player can move in the field.
 */

namespace MainScene
{
    public class PlayerMovement : MonoBehaviour
    {
        // Member Variables
        private Vector2 _startingPosition;
        private Rigidbody2D _rb;
        // Boundary Holder to apply the game object boundary holder to this PlayerMovement Script:  
        [FormerlySerializedAs("BoundaryHolder")] public Transform boundaryHolder;
        private Boundary _playerBoundary;
        // Collider for detecting collisions
        private Collider2D _playerCollider;
        // Sprite render for assigning a game sprite to
        private SpriteRenderer _spriteRenderer;
        //Scorescript so it can be assigned and used within this class
        public ScoreScript scoreScript;
        // Sprite so one can be assigned to it
        public Sprite sprite; 
        private bool _wasJustClicked = true;
        private bool _canMove;

        // Start is called before the first frame update
        private void Start()
        {
            // Accessing the SpriteRenderer that is attached to the Gameobject
            _spriteRenderer = GetComponent<SpriteRenderer>();
            // Assign the sprite passed when loading main scene
            _spriteRenderer.sprite = StaticSpriteClass.CrossSceneInformation == null ? sprite : StaticSpriteClass.CrossSceneInformation;
            //Pass the name of the team onto the UI Manager so it can be displayed
            scoreScript.SetPlayerTeamName(_spriteRenderer.sprite.name);
            // Assigning Rigidbody to game object this script set on.
            _rb = GetComponent<Rigidbody2D>();
            //Accessing Collider2D attached to the Gameobject
            _playerCollider = GetComponent<Collider2D>();
            _startingPosition = _rb.position;
            //Setting the boundary cords of the child game objects when the game starts.
            // Used to keep the player pusher object inside the boundary.
            _playerBoundary = new Boundary(boundaryHolder.GetChild(0).position.y,
                boundaryHolder.GetChild(1).position.y,
                boundaryHolder.GetChild(2).position.x,
                boundaryHolder.GetChild(3).position.x);
        }// End start

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButton(0)) 
            {
                // NOTE: Issue when the cameras projection is set to 'Perspective', keep as 'Orthographic'
                //Setting world cords, need to covert from screen cords as this varies depending on resolution
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
                //If statement to check if the player object was just clicked, this is to stop a player pressing a point
                // in the world cords and the pusher jumping to that point
                //The pusher must be dragged to that point
                if (_wasJustClicked)
                {
                    _wasJustClicked = false;
                    // If the player asset was clicked from inside the transform axis the player can then move.
                    // else you can not move
                    _canMove = _playerCollider.OverlapPoint(mousePos);
                    // End if else for can move when clicked
                }// End if

                if (!_canMove) return;
                Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, _playerBoundary.Left,
                        _playerBoundary.Right),
                    Mathf.Clamp(mousePos.y, _playerBoundary.Down,
                        _playerBoundary.Up));
                _rb.MovePosition(clampedMousePos);
            }//end if
            else
                _wasJustClicked = true;
        }// End Update Function

        //Function which will reset the puck to the starting position when the game restarts 
        public void ResetPosition()
        {
            _rb.position = _startingPosition;
        }//End function
    }//End class
}// End namespace
