using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform parent;
    public GameObject enemyPrefab;
    [SerializeField] float secondsBetweenSpawns = 3f;
    public int waves;
    
    // Start is called before the first frame update
   void Start()
    {
        
       StartCoroutine(WaitAndSpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitAndSpawnEnemies()
    {
        int currentWave=0;
        while(currentWave<waves){ 
        yield return new WaitForSeconds(secondsBetweenSpawns);
        GameObject enemyClone = Instantiate(enemyPrefab, new Vector3(0f, 0f, 10f), Quaternion.identity);
        enemyClone.transform.parent = parent;
        currentWave++;
        }
    }
}
