using UnityEngine;

/* Cathal Butler | G00346889 | Mobile Application Development 3 Project.
 * BoundarySetter class. This class is used to get all the boundary points of the pitch with a PolygonCollider
 * then set them as the points for a EdgeCollider2D game object. This is needed has when you have objects with
 * Ridgebody2D inside of any of the other colliders its pushes them out of bounds when the game starts.
 * This was adapted from here: https://www.youtube.com/watch?v=NbvcfMjAlQ4 
 */
 
namespace MainScene
{
    public class BoundarySetter : MonoBehaviour
    {
        private void Awake()
        {
            PolygonCollider2D pg = GetComponent<PolygonCollider2D>();
            if (pg == null)
                pg = gameObject.AddComponent<PolygonCollider2D>();

            //An array to store the points from the polygon collider
            Vector2[] points = pg.points;
            // Add a new game object EdgeCollider2D
            EdgeCollider2D bounderEdges = gameObject.AddComponent<EdgeCollider2D>();
            //Set the EdgeCollider2D to the points got by the PolygonCollider2D
            bounderEdges.points = points;
            //Destroy the PolygonCollider2D as we dont need it anymore.
            Destroy(pg);
        }//End Awake()
    }//End class
}//End namespaces