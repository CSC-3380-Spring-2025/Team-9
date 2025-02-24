using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using UnityEditor;

public class Level
{
    public Chunk start = new Chunk();
    public Chunk end = new Chunk();
    public Chunk pivot = new Chunk();
    public Chunk extra = new Chunk();
    
    public List<Chunk> chunkList = new List<Chunk>();
    public Level()
    {
        PositionChunks();
        ScaleRoomPositions();
    }
    void PositionChunks()
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