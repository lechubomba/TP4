using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject[] obstaclePrefabs;
    public float spawnInterval = 2f;
    public float spawnDistance = 10f;

    private float spawnTimer = 0f;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnObstacle();
            spawnTimer = 0f;
        }
    }

    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstaclePrefab = obstaclePrefabs[randomIndex];

        Vector3 spawnPosition = playerTransform.position + new Vector3(spawnDistance, 0f, 0f);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}