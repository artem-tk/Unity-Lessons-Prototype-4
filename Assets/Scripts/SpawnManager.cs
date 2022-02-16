using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject EnemyPrefab;

    private float SpawnRange = 9.0f;
    void Start()
    {
        Instantiate(EnemyPrefab, GenerateSpawnPosition(), EnemyPrefab.transform.rotation);
    }

    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float SpawnPositionX = Random.Range(-SpawnRange, SpawnRange);
        float SpawnPositionZ = Random.Range(-SpawnRange, SpawnRange);

        Vector3 RandomPosition = new Vector3(SpawnPositionX, 0, SpawnPositionZ);

        return RandomPosition;
    }
}
