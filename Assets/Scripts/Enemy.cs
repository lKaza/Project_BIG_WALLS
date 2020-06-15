using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int HP = 200;
    [SerializeField] Collider myCollider;
    [SerializeField] ParticleSystem dmgFX;
    [SerializeField] ParticleSystem deathFX;
    public bool isAlive = true;
    public GameObject enemyPrefab;
    


    int getHP()
    {
        return HP;
    }

    public void TakeDMG(int dmg)
    {
        HP -= dmg;
        if (HP <= 0)
        {
            deathFX = Instantiate(deathFX,transform.position,Quaternion.identity);
            deathFX.Play();
            Destroy(gameObject);
        }
       
    }
    private void OnParticleCollision(GameObject other) {
        TakeDMG(20);
        dmgFX.Play();
    }
}
