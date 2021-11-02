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
        //this will call the findpath method
        FindPath();
        //this will call the return to start method
        ReturnToStart();
        //thjs will start the followpath method
        StartCoroutine(FollowPath());

    }

    //this will find the path objects
    void FindPath()
    {
        //deletes the previous path and adds a new one
        path.Clear();
        //any object that has the tag path,, will be placed into the gameobject array
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        
        //it will loop through the gameobject array
        foreach (GameObject waypoint in waypoints)
        {
            //it will add the objects in the array to the path component list
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    //this will make the enemy go to the first path tile
    void ReturnToStart()
    {
        //this will go to the first path tile
        transform.position = path[0].transform.position;
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
        //this will happen once the object reaches the end of the path
        Destroy(gameObject);
    }
}
