using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject TowerPrefab;
    //this is where you can mark the tiles as isplaceable true or false in the unity inspector
    [SerializeField] bool isPlaceable;

    //this will allow the bool isplaceable to be visible to other script files
    public bool IsPlaceable { get { return isPlaceable; } }

    //what will happen when user clicks on a ouse
    void OnMouseDown()
    {
        //if the tile have isplaceable as true
        if (isPlaceable)
        {
            //this will cause the tower to spawn when clicked
            Instantiate(TowerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
        
    }
}
