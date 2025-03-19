using System.Collections.Generic;
using UnityEngine;
public abstract class AbstractChunk
{
    public Vector2 chunkPosition = Vector2.zero;
    public Vector2 ChunkDirection = Vector2.zero;

    public List<AbstractRoom> roomList = new List<AbstractRoom>();

    protected abstract void SetChunkList();

    protected void MoveChunk(Vector2Int dir)
    {
        foreach (AbstractRoom room in roomList)
        {
            room.roomPos = room.roomPos + dir;
        }
        chunkPosition = chunkPosition + dir;
    }
    protected static Vector2 GetDirection()
    {
        int index = (Mathf.FloorToInt(UnityEngine.Random.value * 3.99f));
        switch (index)
        {
            case 0: return Vector2.up;
            case 1: return Vector2.down;
            case 2: return Vector2.left;
            case 3: return Vector2.right;
            default: return Vector2.zero;
        }
    }

    public abstract void ScaleRoomPositions();
}
