using UnityEngine;
using UnityEngine.Tilemaps;

public class DemoLevelGeneration : MonoBehaviour
{

    public Tilemap tilemap;
    public Tile wall;
    public Tile floor;

    public int tileCount = default;

    public void PlaceTiles()
    {
        Walker1x1ChunkLevel level = new Walker1x1ChunkLevel();

        tilemap.ClearAllTiles();
        tileCount = default;

        foreach (Walker4rmChunk chunk in level.chunkList)
        {
            foreach (WalkerRoom1x1 room in chunk.roomList)
            {
                CycleRoom(room);
            }
        }
    }
    private void CycleRoom(WalkerRoom1x1 room)
    {
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
