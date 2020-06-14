using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
   
    
    
    void Start() {
        
    }
    
    void Update()
    {
        Shooting();

    }

    private void Shooting()
    {
        objectToPan.LookAt(targetEnemy);
    }



}
