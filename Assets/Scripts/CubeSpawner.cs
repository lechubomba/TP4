using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnInterval = 2f;
    public float cubeLifetime = 5f;

    private float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnCube();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnCube()
    {
        GameObject cube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
        Destroy(cube, cubeLifetime);
    }
}

