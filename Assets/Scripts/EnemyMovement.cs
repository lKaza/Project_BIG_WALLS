using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed=0.5f;
    [SerializeField] ParticleSystem goalVFX;
    
    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        StartCoroutine(FollowPath(pathfinder.getPath()));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(speed);
        }
        ReachGoal();
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
        
    }
  
}
