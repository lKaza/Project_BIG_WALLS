using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5; //change to q size
    [SerializeField] Transform parent;
    Queue<Tower> towerQ = new Queue<Tower>();
    Tower oldestTower;
    
    

    public void AddTower(Waypoint baseWaypoint)
    {
       
        if(towerQ.Count<towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            
            MoveOldestTower(baseWaypoint);
        }

    }
 
    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);   
        newTower.transform.parent = parent;
        baseWaypoint.isPleaceable = false;

        newTower.towerPos = baseWaypoint;


        towerQ.Enqueue(newTower);
        
        
    }

    private void MoveOldestTower(Waypoint waypoint)
    {
       
        //set placeable
        oldestTower =  towerQ.Dequeue();

        oldestTower.towerPos.isPleaceable = true;
        waypoint.isPleaceable = false;
        oldestTower.transform.position = waypoint.transform.position;
        oldestTower.towerPos = waypoint;
    
        //set the position of the base
        towerQ.Enqueue(oldestTower);
        
        //old tower to the top of the q
       
    }

}
