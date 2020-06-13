using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int,Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startPoint;
    [SerializeField] Waypoint endPoint;
    Vector2Int[] directions = {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
    };
    [SerializeField] Vector2Int Explorer;
    bool first = true;
    // Start is called before the first frame update
    void Start()
    {

        LoadBlocks();
        ColorFirstAndLast();
        ExploreNeighbours(Explorer);
    }

    private void ExploreNeighbours(Vector2Int position)
    {
        print("Using " + startPoint.GetGridPos() + " as center");
        foreach(Vector2Int direction in directions) {         
            Vector2Int explorationCoordinates = startPoint.GetGridPos() + direction;
            print("Exploring and Painting "+(explorationCoordinates));
            try{
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }catch{
                print("Some blocks cant be found");
            }
            

        }
    }

    private void ColorFirstAndLast()
    {
        startPoint.SetTopColor(Color.cyan);
        endPoint.SetTopColor(Color.magenta);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        
        foreach(Waypoint waypoint in waypoints)
        {
            if(grid.ContainsKey(waypoint.GetGridPos()) )
            {
                Debug.LogWarning("Skipping overlap "+waypoint);
            }else{
                waypoint.SetTopColor(Color.black);
                grid.Add(waypoint.GetGridPos() ,waypoint);
            } 
        }
       
       
    }
   
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
