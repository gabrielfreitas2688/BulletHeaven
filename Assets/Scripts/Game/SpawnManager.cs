using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public WaveData[] waves;

    public Transform[] spawnPosition;
    public GameObject enemy;
    public GameObject[] enemiesAlive;
    bool isSpawning = false;

    public static SpawnManager Instance;
    void Awake()
    {

        if (Instance == null)
        {

            Instance = this;

        }
        else
        {

            Destroy(gameObject);
        }

    }

        void Start()
    {
        GameManeger.Instance.currentWave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesAlive.Length == 0 && !isSpawning && GameManeger.Instance.currentWave < waves.Length)
        {
            StartCoroutine(SpawnEnemies());
        }

    }

    IEnumerator SpawnEnemies()
    {
        GameManeger.Instance.waveText.text = "WAVE: " + (GameManeger.Instance.currentWave + 1).ToString();
        isSpawning = true;
        WaveData countWave = waves[GameManeger.Instance.currentWave];
        
        foreach(EnemyGroup w in countWave.enemies)
        {
            for(int i = 0; i < w.count; i++)
            {
                
                Vector3 randomOffset = Random.insideUnitCircle * 1.5f;

                int randomIndex = Random.Range(0, spawnPosition.Length);

                Transform spawnSorted = spawnPosition[randomIndex];

                Instantiate(w.enemyPrefab, spawnSorted.position + randomOffset, Quaternion.identity);

                yield return new WaitForSeconds(countWave.spawnRate);
                
            }
        }

        GameManeger.Instance.currentWave++;
        
        isSpawning = false;
        
        
    }
}
