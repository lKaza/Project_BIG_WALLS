using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    
    [SerializeField] ParticleSystem harpoon;
    [SerializeField] float AttackRange=50f;
   
    Transform targetEnemy;
    
    void Start() {
        
    }
    
    void Update()
    {
        SetTargetEnemy();
        if(targetEnemy){
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }else{
            Shoot(false);
            
        }
        

    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<Enemy>();
        if(sceneEnemies.Length == 0){ return; }
        Transform closestEnemy = sceneEnemies[0].transform;
        
        foreach(Enemy testEnemy in sceneEnemies){
            closestEnemy = GetClosest(closestEnemy,testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        float distanceToA = Vector3.Distance(transformA.position,transform.position);
        float distanceToB = Vector3.Distance(transformB.position,transform.position);
       if(distanceToA<distanceToB){
           return transformA;
       }
           return transformB;
       
    }

    private void FireAtEnemy()
    {
        
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, objectToPan.transform.position);
        if(distanceToEnemy <= AttackRange){
            Shoot(true);
        }else{
            Shoot(false);
        }
        
    }

    private void Shoot(bool isActive)
    {
        
        var emissionModule = harpoon.emission;
        
        emissionModule.enabled = isActive;

    }
}
