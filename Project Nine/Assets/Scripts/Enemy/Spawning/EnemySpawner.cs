using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float SpawnTime = 3f;
    public Transform[] SpawnPoints;
    public int MaxEnemies = 5;


    private int _currentEnemies = 0;


    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }


    // spawns enemies every SpawnTime seconds
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (_currentEnemies < MaxEnemies)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(SpawnTime);
        }
    }


    // randomly picks a spawn point inside the array and instantiates an enemy
    private void SpawnEnemy()
    {
        if (SpawnPoints.Length == 0)
        {
            Debug.LogError("no spawn points found for the enemy spawner");
            return;
        }

        Transform spawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity);
        _currentEnemies++;
    }

    // should be called by the enemy when it dies
    public void RemoveEnemy()
    {
        _currentEnemies--;
    }

}
