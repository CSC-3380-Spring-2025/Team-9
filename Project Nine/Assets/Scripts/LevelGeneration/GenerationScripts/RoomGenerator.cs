using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomGenerator : MonoBehaviour
{
    public Tilemap tilemap;

    public Tile wall;
    public Tile floor;

    public int tileCount = default;
    public void PlaceTiles()
    {
        tilemap.ClearAllTiles();
        tileCount = default;

        WalkerRoom1x1 room = new WalkerRoom1x1();

        Vector3Int initialTilePlacer = new Vector3Int((int)room.roomPos.x, (int)room.roomPos.y, 0);

        for (int i = 0; i < room.roomGrid.GetLength(0); i++)
        {
            for (int j = 0; j < room.roomGrid.GetLength(1); j++)
            {
                Vector3Int tilePlacer = new Vector3Int(initialTilePlacer.x + i, initialTilePlacer.y + j, 0);

                if (room.roomGrid[i, j] == AbstractRoom.Grid.FLOOR)
                {
                    tilemap.SetTile(tilePlacer, floor);
                    tileCount++;
                }
                if (room.roomGrid[i, j] == AbstractRoom.Grid.WALL)
                {
                    tilemap.SetTile(tilePlacer, wall);
                }
            }
        }
    }
}