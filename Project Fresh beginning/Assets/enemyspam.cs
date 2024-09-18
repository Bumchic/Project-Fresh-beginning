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

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            Tilemap selectedTilemap = tilemaps[Random.Range(0, tilemaps.Count)];
            Vector3Int randomTilePosition = GetRandomTilePosition(selectedTilemap);
            Vector3 spawnPosition = selectedTilemap.GetCellCenterWorld(randomTilePosition);

            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = enemyPrefabs[rand];
            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3Int GetRandomTilePosition(Tilemap tilemap)
    {
        // Get the bounds of the selected tilemap
        BoundsInt bounds = tilemap.cellBounds;

        // Loop through the bounds to find a valid tile
        for (int attempts = 0; attempts < 10; attempts++) // Try multiple times to find a valid tile
        {
            int randomX = Random.Range(bounds.x, bounds.xMax);
            int randomY = Random.Range(bounds.y, bounds.yMax);
            Vector3Int tilePosition = new Vector3Int(randomX, randomY, 0);

            // Check if the tile has a tile
            if (tilemap.HasTile(tilePosition))
            {
                // Spawn just above the tile
                Vector3Int spawnPosition = new Vector3Int(randomX, randomY + 1, 0); // Adjust Y to spawn on top
                return spawnPosition;
            }
        }

        return Vector3Int.zero; // Return zero if no valid position found
    }

}
