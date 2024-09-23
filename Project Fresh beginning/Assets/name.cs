using UnityEngine;
using UnityEngine.Tilemaps;

public class TileRemover : MonoBehaviour
{
    public Tilemap tilemap; // Kéo thả Tilemap vào đây
    public TileBase tileToRemove; // Kéo thả loại tile muốn xóa vào đây

    void Start()
    {
        RemoveTiles();
    }

    void RemoveTiles()
    {
        BoundsInt bounds = tilemap.cellBounds;
        for (int x = bounds.x; x < bounds.xMax; x++)
        {
            for (int y = bounds.y; y < bounds.yMax; y++)
            {
                TileBase tile = tilemap.GetTile(new Vector3Int(x, y, 0));
                if (tile == tileToRemove)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), null); // Xóa tile
                }
            }
        }
    }
}
