using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class CubeEditor : MonoBehaviour
{
   
    PathFinder path;
    Waypoint waypoint; 
    int gridSize;


    private void Awake() {
        waypoint = GetComponent<Waypoint>();
    }

    void Start(){
      
        gridSize = waypoint.GetGridSize();   
    }


    void Update()
    {
        GetGridPos();
        NameBlock();
       
    }

    private void GetGridPos()
    {
       
        transform.position = new Vector3(waypoint.GetGridPos().x * waypoint.GetGridSize(), 
                                        0f, 
                                        waypoint.GetGridPos().y * waypoint.GetGridSize());
    }

    private void NameBlock()
    {
        TextMesh textMesh;
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = (waypoint.GetGridPos().x)  + 
                        "," + 
                        (waypoint.GetGridPos().y);  
        gameObject.name = textMesh.text;
    }
}
