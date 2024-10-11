using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;


    private Camera mainCamera;
    private float lastSpawnX = 0f; // Last spawn position in the x-axis
    private float spawnDistance = 30f; // Distance to spawn a new enemy
    private void Start()
    {
        mainCamera = Camera.main;
        lastSpawnX = mainCamera.transform.position.x + spawnDistance; // Initialize with the camera's starting position + spawn distance
    }

    private void Update()
    {
        if (canSpawn)
        {
            float cameraX = mainCamera.transform.position.x;

            // Check if the camera has moved beyond the last spawn position
            if (cameraX >= lastSpawnX)
            {
                SpawnEnemy();
                lastSpawnX += spawnDistance; // Update the last spawn position for the next enemy
            }
        }
    }

    private void SpawnEnemy()
    {
        int rand = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyToSpawn = enemyPrefabs[rand];


        // Set the spawn position to the right of the camera
        Vector3 spawnPosition = new Vector3(lastSpawnX+7f, enemyToSpawn.transform.position.y, 0f);
        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
    }
}
