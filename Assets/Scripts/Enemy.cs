using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHP = 200;
    [SerializeField] Collider myCollider;
    [SerializeField] ParticleSystem dmgFX;
    [SerializeField] ParticleSystem deathFX;   
    [SerializeField] AudioClip dmgSFX;
    [SerializeField] AudioClip deathSFX;
    Vector3 cameraPos;
    private int currentHP;
    //[SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudioSource;

    public bool isAlive = true;
    public GameObject enemyPrefab;
    
    public event Action<float> OnHealthPcChanged = delegate {};
    
    
    private void Start() {
        currentHP = maxHP;
        cameraPos = FindObjectOfType<Camera>().transform.position;
      myAudioSource = GetComponent<AudioSource>();
    }

    int getHP()
    {
        return maxHP;
    }

    public void TakeDMG(int dmg)
    {
        currentHP -= dmg;
        myAudioSource.PlayOneShot(dmgSFX);
       
        float currentHPPc = (float)currentHP/(float) maxHP;
        OnHealthPcChanged(currentHPPc);
        if (currentHP <= 0)
        {
            Death();
        }

    }

    private void Death()
    {
        //GetComponent<AudioSource>().PlayOneShot(enemyDeathSFX);
        deathFX = Instantiate(deathFX, transform.position, Quaternion.identity);
        deathFX.Play();
        var ccamera = new Vector3(0,0,0);
        ccamera = ccamera-cameraPos;
        AudioSource.PlayClipAtPoint(deathSFX,ccamera,10);
        
        
        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other) {
        
        TakeDMG(20);
        
    }

}
