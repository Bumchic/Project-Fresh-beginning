using UnityEngine;
using UnityEngine.Tilemaps;

public class InfiniteFloor : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase floorTile;
    public int width = 20;  // Width of the visible area
    public int height = 10; // Height of the visible area
    public Transform player;
    private Vector3Int lastPlayerPosition;

    void Start()
    {
        lastPlayerPosition = Vector3Int.RoundToInt(player.position);
        GenerateFloor();
    }

    void Update()
    {
        Vector3Int playerPosition = Vector3Int.RoundToInt(player.position);

        if (Mathf.Abs(playerPosition.x - lastPlayerPosition.x) >= width ||
            Mathf.Abs(playerPosition.y - lastPlayerPosition.y) >= height)
        {
            lastPlayerPosition = playerPosition;
            GenerateFloor();
        }
    }

    void GenerateFloor()
    {
        tilemap.ClearAllTiles();

        Vector3Int playerPosition = Vector3Int.RoundToInt(player.position);
        Vector3Int startPosition = new Vector3Int(playerPosition.x - width / 2, playerPosition.y - height / 2, 0);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tilemap.SetTile(startPosition + new Vector3Int(x, y, 0), floorTile);
            }
        }
    }
}
