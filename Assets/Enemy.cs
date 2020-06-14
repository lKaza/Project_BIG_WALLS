using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int HP = 2000;
    [SerializeField] Collider myCollider;
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
            Destroy(gameObject);
        }
       
    }

    private void OnParticleCollision(GameObject other) {
        TakeDMG(20);
    }
}
