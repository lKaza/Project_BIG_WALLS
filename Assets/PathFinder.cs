using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    
    Dictionary<Vector2Int,Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startPoint;
    [SerializeField] Waypoint endPoint;

    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;

    Vector2Int[] directions = {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
    };

    bool first = true;
    // Start is called before the first frame update
    void Start()
    {

        LoadBlocks();
        ColorFirstAndLast();
        //ExploreNeighbours();
        PathFind();
    }

    private void PathFind()
    {
        
        queue.Enqueue(startPoint);
        while (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();        
            print("Searching from " + searchCenter); //todo remove log
            StopIfSame(searchCenter);
            ExploreNeighbours(searchCenter);
            searchCenter.isExplored = true;
        }
      

    }

    private void StopIfSame(Waypoint searchCenter)
    {
        if (searchCenter == endPoint)
        {
            print("Start and End are the same"); //todo remove log
            isRunning = false;
        }
       
    }

    private void ExploreNeighbours(Waypoint from)
    {
        print(isRunning);
        if(!isRunning){
            return;
        }
        {
            print("Searching...");
            foreach(Vector2Int direction in directions) 
            {         
                Vector2Int neighbourCoordinates = from.GetGridPos() + direction;
                print("Exploring and Painting "+(neighbourCoordinates));
                try
                {
                    QueueNewNeighbours(neighbourCoordinates);
                }
                catch
                {
                    print("Some blocks cant be found");
                }          
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if(neighbour.isExplored == false){
            neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);
            print("Queue " + neighbour);
        }else{
            
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
