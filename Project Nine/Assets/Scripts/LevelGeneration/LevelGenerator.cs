using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using System;

public class LevelGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wall;
    public Tile floor;

    public int tileCount = default;
    void Start()
    {

    }
    public void PlaceTiles()
    {
        tilemap.ClearAllTiles();
        tileCount = default;
        Level level = new Level();

        foreach(Chunk chunk in level.chunkList)
        {
            foreach(Room room in chunk.roomList)
            {
                Vector3Int initialTilePlacer = new Vector3Int((int)room.roomPosition.x , (int)room.roomPosition.y, 0);

                for(int i = 0; i < room.roomGrid.GetLength(0); i++)
                {
                    for(int j = 0; j < room.roomGrid.GetLength(1); j++)
                    {
                        Vector3Int tilePlacer = new Vector3Int(initialTilePlacer.x + i, initialTilePlacer.y + j, 0);
                        if (room.roomGrid[i,j] == Room.Grid.FLOOR)
                        {
                            tilemap.SetTile(tilePlacer, floor);
                            tileCount++;
                        }
                        if (room.roomGrid[i,j] == Room.Grid.WALL)
                        {
                            tilemap.SetTile(tilePlacer, wall);
                        }
                    }
                }
            }
        }
    }
}