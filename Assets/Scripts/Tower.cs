using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] ParticleSystem harpoon;
    [SerializeField] float AttackRange=50f;
   
    
    
    void Start() {
        
    }
    
    void Update()
    {
        if(targetEnemy){
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }else{
            Shoot(false);
            print("searching");
        }
        

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
