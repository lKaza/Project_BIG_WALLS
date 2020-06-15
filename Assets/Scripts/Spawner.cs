using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform parent;
    public GameObject enemyPrefab;
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] TextMeshProUGUI enemyText;
    int enemiesQuantity;
    
    // Start is called before the first frame update
   void Start()
    {
        
       StartCoroutine(WaitAndSpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemyText();
    }
    private void UpdateEnemyText()
    {
        enemyText.text = enemiesQuantity.ToString();
    }
    IEnumerator WaitAndSpawnEnemies()
    {
        
        while(true){ //forever
        
        yield return new WaitForSeconds(secondsBetweenSpawns);
        GameObject enemyClone = Instantiate(enemyPrefab, new Vector3(0f, 0f, 10f), Quaternion.identity);
        enemyClone.transform.parent = parent;
        enemiesQuantity++;
        
        }
    }
}
