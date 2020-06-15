using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        StartCoroutine(PrintWayPoints(pathfinder.getPath()));
    }

    IEnumerator PrintWayPoints(List<Waypoint> path)
    { 
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;          
            yield return new WaitForSeconds(1f);
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
