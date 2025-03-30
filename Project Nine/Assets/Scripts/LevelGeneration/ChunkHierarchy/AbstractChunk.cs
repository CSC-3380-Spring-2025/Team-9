using System.Collections.Generic;
using UnityEngine;
public abstract class AbstractChunk
{
    public Vector2 chunkPosition = Vector2.zero;
    public Vector2 chunkDirection = Vector2.zero;

    public abstract void MoveChunk(Vector2 dir);
    public abstract void ScaleRoomPositions();
    public static Vector2 GetDirection()
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
}