using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseHP : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpText;
    
    [SerializeField] int hpBase=100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   

    void changeHPText(int dmg){
        hpText.text = hpBase.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        hpBase -= 10;
        changeHPText(10);
    }
}
