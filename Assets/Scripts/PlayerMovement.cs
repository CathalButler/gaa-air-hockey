using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Varaibles
    bool wasJustClicked = true;
    bool canMove;
    // Used for how big the sprite is 
    Vector2 playerSize;
    // Start is called before the first frame update
    void Start()
    {
        playerSize = gameObject.GetComponent<SpriteRenderer>().bounds.extents;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (wasJustClicked)
            {
                wasJustClicked = false;

                // If the player asset was clicked from inside the transform axis the player can then move.
                if ((mousePos.x >= transform.position.x && mousePos.x < transform.position.x + playerSize.x ||
                mousePos.x <= transform.position.x && mousePos.x > transform.position.x - playerSize.x) &&
                (mousePos.y >= transform.position.y && mousePos.y < transform.position.y + playerSize.y ||
                mousePos.y <= transform.position.y && mousePos.y > transform.position.y - playerSize.y))
                {
                    canMove = true;
                }
                else
                {
                    // If it is not within the assets transform axis then the player cannot move.
                    canMove = false;    
                }// End if else for can move when clicked
            }// End if

            if (canMove)
            {
                transform.position = mousePos;
            }
        }
        else
        {
            wasJustClicked = true;
        }
    }// End Update Function
}// End class
