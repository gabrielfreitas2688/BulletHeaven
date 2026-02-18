using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPosition;
    public GameObject enemy;
    public GameObject[] enemiesAlive;
    bool isSpawning = false;
    
    void Start()
    {
        //StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesAlive.Length == 0 && !isSpawning)
        {
            StartCoroutine(SpawnEnemies());
        }

    }

    IEnumerator SpawnEnemies()
    {
        isSpawning = true;
        
       
            for (int w = 0; w < GameManeger.Instance.currentWave; w++)
            {
               
                for (int i = 0; i < spawnPosition.Length; i++)
                {
                    Vector3 randomOffset = Random.insideUnitCircle * 1.5f;

                    int randomIndex = Random.Range(0, spawnPosition.Length);

                    Transform spawnSorted = spawnPosition[randomIndex];

                    Instantiate(enemy, spawnSorted.position + randomOffset, Quaternion.identity);

                    yield return new WaitForSeconds(0.02f);
                    
                }
             yield return new WaitForEndOfFrame();
                
            }
        GameManeger.Instance.currentWave++;
        isSpawning = false;
        GameManeger.Instance.waveText.text = "WAVE: " + (GameManeger.Instance.currentWave - 1).ToString();



    }
}
