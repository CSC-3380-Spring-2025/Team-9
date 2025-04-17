using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DemoLevelGeneration : MonoBehaviour
{
    public Walker1x1ChunkLevel level;

    public Tilemap floorTilemap;
    public Tilemap wallTilemap;
    public Tile wall;
    public Tile floor;

    public int tileCount = default;

    [SerializeField] private SnailSpawn snailSpawn;

    [SerializeField] private GameObject doorPrefab;
    private DoorSpawn doorSpawn;

    [SerializeField] private GameObject playerPrefab;
    private LevelPlayerSpawn playerSpawn;

    public void GenerateLevel()
    {
        level = new Walker1x1ChunkLevel();

        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
        tileCount = default;

        foreach (Walker4rmChunk chunk in level.chunkList)
        {
            foreach (WalkerRoom1x1 room in chunk.roomList)
            {
                CycleRoom(room);
            }
        }
        PlayerSpawn();
        DoorSpawn();
        EnemySpawnAlgorithms();
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
                    floorTilemap.SetTile(tilePlacer, floor);
                    tileCount++;
                }
                if (room.roomGrid[i, j] == AbstractRoom.Grid.WALL)
                {
                    wallTilemap.SetTile(tilePlacer, wall);
                }
            }
        }
    }
    private void PlayerSpawn()
    {
        playerSpawn = new LevelPlayerSpawn(level, playerPrefab);
        playerSpawn.SetPlayerPosition();
    }
    private void DoorSpawn()
    {
        doorSpawn = new DoorSpawn(level, doorPrefab);
        doorSpawn.SetDoorPosition();
    }
    private void EnemySpawnAlgorithms()
    {
        snailSpawn.DestroySnail();
        snailSpawn.SetSpawnLocation(level);
    }
}
