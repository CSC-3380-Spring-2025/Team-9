using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using UnityEditor;

public class Level
{
    //Creation of all Chunk objects within the level class (each with new particular names)
    public Chunk start = new Chunk();
    public Chunk end = new Chunk();
    public Chunk pivot = new Chunk();
    public Chunk extra = new Chunk();
    
    //chunkList created to hold all chunks in a iterable structure
    public List<Chunk> chunkList = new List<Chunk>();

    /*
     * constructor that runs methods for the Level Object
     * 
     * a) PositionChunks()
     * b) ScaleRoomPositions()
     */
    public Level()
    {
        PositionChunks();
        ScaleRoomPositions();
    }

    /*
     * This Method responsible for moving chunks to acceptable positions (no collisions of rooms within all chunks)
     */
    private void PositionChunks()
    { 
        Vector2 dir = Chunk.GetDirection();

        start.ChunkDirection = dir;
        while (start.CheckCollision(pivot))
        {
            start.MoveChunk(start.ChunkDirection);
        }
        end.ChunkDirection = dir * -1;
        while(end.CheckCollision(pivot) || end.CheckCollision(start))
        {
            end.MoveChunk(end.ChunkDirection);
        }
        extra.ChunkDirection = Chunk.GetDirection();
        while(extra.CheckCollision(pivot) || extra.CheckCollision(start) || extra.CheckCollision(end))
        {
            extra.MoveChunk(extra.ChunkDirection);
        }
    }

    /*
     * This Method is responsable for the scaling of all positions of rooms and chunks by *32
     * (this must happen because the tileset references these scaled positions to place on a cohesive tilemap)
     */
    void ScaleRoomPositions()
    {
        chunkList.Add(pivot);
        chunkList.Add(extra);
        chunkList.Add(end);
        chunkList.Add(start);

        foreach(Chunk chunk in chunkList)
        {
            foreach(Room room in chunk.roomList)
            {
                room.roomPosition = room.roomPosition * 32;
            }
        }
    }
}