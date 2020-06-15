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
    [SerializeField] AudioClip myAudio;
    int enemiesQuantity;
    AudioSource myAudioSource;
    
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
        GameObject enemyClone = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemyClone.transform.parent = parent;
        enemiesQuantity++;
            GetComponent<AudioSource>().PlayOneShot(myAudio);
        
        }
    }
}
