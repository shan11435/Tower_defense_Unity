using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    //creates a list using the waypoint class
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    //this can edit how fast the object travels, this also fixes the issue if we accidentally put a negative number so the games doesn't break
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //thjs will start the followpath method
        StartCoroutine(FollowPath());

    }

    IEnumerator FollowPath()
    {
        //for loop for the waypoint and looping through the list
        foreach (Waypoint waypoint in path)
        {
            
            Vector3 startPosition = transform.position;
            //this is the coordinates for the ppints in the waypoint editor
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;
            
            //this is responsible for the object to turn and face where they're moving
            transform.LookAt(endPosition);

            //while the object reaches 1 travel percent
            while (travelPercent < 1f)
            {
                //this is responsible for player speed
                travelPercent += Time.deltaTime * speed;
                //this will cause the object to move smoothly
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
