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

    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>(); 

    // Start is called before the first frame update

    public List<Waypoint> getPath(){
        LoadBlocks();
        ColorFirstAndLast();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }

    private void CreatePath()
    {
        path.Add(endPoint);
        Waypoint previous = endPoint.exploredFrom;
        while(previous != startPoint){
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(previous);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();        
            StopIfSame();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }      
    }

    private void StopIfSame()
    {
        if (searchCenter == endPoint)
        {
            searchCenter.SetTopColor(Color.yellow);
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {  
        if(!isRunning)
        {
            return;
        }
            {        
                foreach(Vector2Int direction in directions) 
                {         
                    Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
                   if(grid.ContainsKey(neighbourCoordinates)){
                    QueueNewNeighbours(neighbourCoordinates);
                   }                                          
                }
            }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if(neighbour.isExplored || queue.Contains(neighbour)){
            return;
        }else{                     
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;     
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
                grid.Add(waypoint.GetGridPos() ,waypoint);
            } 
        }      
    }
}
