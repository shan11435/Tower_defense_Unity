using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    //this is where you can mark the tiles as isplaceable true or false in the unity inspector
    [SerializeField] bool isPlaceable;

    //this will allow the bool isplaceable to be visible to other script files
    public bool IsPlaceable { get { return isPlaceable; } }

    //what will happen when user clicks on a mouse
    void OnMouseDown()
    {
        //if the tile have isplaceable as true
        if (isPlaceable)
        {
            //if we manage to place a tower this will return true, or if we don't have enough money then we won't be able to place a tower and this will return false
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            //this will make isplaceable the opposite of isplaced value for example if isPlaced is true, isPlaceable will be false
            isPlaceable = !isPlaced;
        }
        
    }
}
