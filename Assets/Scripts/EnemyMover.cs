using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    //creates a list using the waypoint class
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    [SerializeField] private float waitTime = 1f;
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
            //this will move the enemy object
            transform.position = waypoint.transform.position;
            //it will stop for 1 second and restart the method until the loop is finished, and it will no longer run the loop
            yield return new WaitForSeconds(waitTime);
        }
    }
}
