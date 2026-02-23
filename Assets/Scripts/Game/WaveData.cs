using UnityEngine;

[System.Serializable]
public struct EnemyGroup
{
    public GameObject enemyPrefab;
    public int count;
}

[CreateAssetMenu(fileName = "NewWave", menuName = "WaveSystem")]
public class WaveData : ScriptableObject
{
    [Header("Configurações da Onda")]
    public EnemyGroup[] enemies;
    public float spawnRate;
}