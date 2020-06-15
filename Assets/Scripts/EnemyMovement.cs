using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] ParticleSystem goalVFX;
    
    public List<Waypoint> ourpath;
    int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        ourpath = pathfinder.getPath();
       
    }

    

    private void ReachGoal()
    {
        goalVFX = Instantiate(goalVFX, transform.position, Quaternion.identity);
        goalVFX.Play();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        moveSmoothly();
    }

    private void moveSmoothly()
    {
        
        float step = speed * Time.deltaTime;
        if(i>=ourpath.Count){
            Vector3 target = ourpath[ourpath.Count-1].transform.position;
            Vector3 up = new Vector3(0,3f,0);
            target = target+up;
            ReachGoal();
        }else{
            Vector3 target = ourpath[i].transform.position;
            Vector3 up = new Vector3(0, 3f, 0);
            target = target + up;
            Vector3 lTargetDir = target - transform.position;   
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * speed);

        
    
        float distance = Vector3.Distance(transform.position, target);
        if(distance==0 && i<ourpath.Count){
           
            i++;
            
        }
        }
        
            
        
        
        
}
}
