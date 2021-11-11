using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//it needs the textmeshpro component for this script to work
[RequireComponent(typeof(TextMeshPro))]
//this is executed all the time even in edit mode
[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    //Access to waypoint script file
    Waypoint waypoint;
    void Awake()
    {
        //calls the text mesh pro component in inspector
        label = GetComponent<TextMeshPro>();
        //when the game launches, the coordinates will not show in the world map
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        //this fixes the issue of the coordinates not showing when the game is running
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        //this will execute in edit mode
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //this will set the label enabler to the opposite of its current boolean state
            label.enabled = !label.IsActive();
        }
    }

    //this will determine the color of the coordinates based on whether there placed tiles or world tiles
    void SetLabelColor()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    {
        //its dividing the number of the x value in inspector by the x value in the grid settings 
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        //its dividing the number of the z value in inspector by the z value in the grid settings 
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }

    //this will make every object created, change the name automatically based on the current x,y position it's placed in the world
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
