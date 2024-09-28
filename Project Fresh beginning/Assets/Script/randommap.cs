using UnityEngine;
using UnityEngine.Tilemaps;

public class EndlessMapManager2D : MonoBehaviour
{
    public Tilemap tilemap; // Tilemap bạn đã tạo
    public TileBase[] tiles; // Mảng các tiles để sử dụng
    public Transform player; // Đối tượng người chơi
    public float spawnDistance = 10f; // Khoảng cách để sinh đoạn bản đồ mới
    public float deleteDistance = 15f; // Khoảng cách để xóa đoạn bản đồ cũ
    public float maxHeightOffset = 3f; // Khoảng cách tối đa để thay đổi chiều cao

    private Transform playerTransform;
    private Vector3Int lastPlayerPosition;
    private Vector3Int currentTilePosition;

    void Start()
    {
        playerTransform = player.transform;
        lastPlayerPosition = tilemap.WorldToCell(playerTransform.position);
        currentTilePosition = lastPlayerPosition;

        GenerateInitialMap();
    }

    void Update()
    {
        Vector3Int playerCellPosition = tilemap.WorldToCell(playerTransform.position);
        if (Mathf.Abs(playerCellPosition.x - lastPlayerPosition.x) > spawnDistance)
        {
            lastPlayerPosition = playerCellPosition;
            ManageMapSections();
        }
    }

    void GenerateInitialMap()
    {
        for (int i = -1; i <= 1; i++)
        {
            GenerateRow(currentTilePosition.x + i);
        }
    }

    void GenerateRow(int xPosition)
    {
        int rowLength = Mathf.CeilToInt(tilemap.size.x);
        float yOffset = Random.Range(-maxHeightOffset, maxHeightOffset);

        for (int i = 0; i < rowLength; i++)
        {
            Vector3Int position = new Vector3Int(xPosition, Mathf.FloorToInt(yOffset), 0);
            tilemap.SetTile(position, tiles[Random.Range(0, tiles.Length)]);
        }
    }

    void ManageMapSections()
    {
        Vector3Int playerCellPosition = tilemap.WorldToCell(playerTransform.position);

        // Xóa các đoạn bản đồ cũ
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = bounds.x; x < bounds.x + bounds.size.x; x++)
        {
            for (int y = bounds.y; y < bounds.y + bounds.size.y; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);
                if (Mathf.Abs(position.x - playerCellPosition.x) > deleteDistance)
                {
                    tilemap.SetTile(position, null);
                }
            }
        }

        // Sinh các đoạn bản đồ mới
        if (playerCellPosition.x > currentTilePosition.x + spawnDistance)
        {
            currentTilePosition = new Vector3Int(currentTilePosition.x + 1, 0, 0);
            GenerateRow(currentTilePosition.x);
        }
    }
}
