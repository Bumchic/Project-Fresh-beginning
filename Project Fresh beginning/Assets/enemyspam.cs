using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;
    public Transform mainCharacter;
    [SerializeField] private List<Tilemap> tilemaps;

    private List<Vector3> spawnedPositions = new List<Vector3>();
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main; // Cache the main camera
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            Tilemap selectedTilemap = tilemaps[Random.Range(0, tilemaps.Count)];
            Vector3 spawnPosition = GetRandomSpawnPositionOnTiles(selectedTilemap);

            if (spawnPosition != Vector3.zero) // Check if a valid position was found
            {
                int rand = Random.Range(0, enemyPrefabs.Length);
                GameObject enemy = enemyPrefabs[rand];
                Instantiate(enemy, spawnPosition, Quaternion.identity);
                spawnedPositions.Add(spawnPosition);
                Debug.Log($"Spawned enemy at {spawnPosition}");
            }
            else
            {
                Debug.LogWarning("No valid spawn position found.");
            }
        }
    }

    private Vector3 GetRandomSpawnPositionOnTiles(Tilemap tilemap)
    {
        // Get bounds of the tilemap
        BoundsInt bounds = tilemap.cellBounds;

        // Generate random positions
        for (int attempts = 0; attempts < 10; attempts++)
        {
            int randomX = Random.Range(bounds.x, bounds.xMax);
            int randomY = Random.Range(bounds.y, bounds.yMax);
            Vector3Int tilePosition = new Vector3Int(randomX, randomY, 0);

            // Check if there's a tile at the selected position
            if (tilemap.HasTile(tilePosition))
            {
                // Calculate the spawn position just above the tile
                Vector3 spawnPoint = tilemap.GetCellCenterWorld(tilePosition) + new Vector3(0, 1, 0); // Adjust Y to spawn on top

                // Check if this position has already been used
                if (!spawnedPositions.Contains(spawnPoint))
                {
                    return spawnPoint; // Return the valid spawn position
                }
            }
            else
            {
                Debug.Log($"Tile at {tilePosition} is empty.");
            }
        }

        return Vector3.zero; // Return zero if no valid position found
    }
}
