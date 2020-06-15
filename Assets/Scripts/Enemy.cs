using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int HP = 200;
    [SerializeField] Collider myCollider;
    [SerializeField] ParticleSystem dmgFX;
    [SerializeField] ParticleSystem deathFX;   
    [SerializeField] AudioClip dmgSFX;
    [SerializeField] AudioClip deathSFX;
    Vector3 cameraPos;
    //[SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudioSource;

    public bool isAlive = true;
    public GameObject enemyPrefab;
    
    
    private void Start() {
        cameraPos = FindObjectOfType<Camera>().transform.position;
      myAudioSource = GetComponent<AudioSource>();
    }

    int getHP()
    {
        return HP;
    }

    public void TakeDMG(int dmg)
    {
        myAudioSource.PlayOneShot(dmgSFX);
        HP -= dmg;
        
        if (HP <= 0)
        {
            Death();
        }

    }

    private void Death()
    {
        //GetComponent<AudioSource>().PlayOneShot(enemyDeathSFX);
        deathFX = Instantiate(deathFX, transform.position, Quaternion.identity);
        deathFX.Play();
        AudioSource.PlayClipAtPoint(deathSFX,cameraPos,10);
        
        
        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other) {
        
        TakeDMG(20);
        
    }

}
