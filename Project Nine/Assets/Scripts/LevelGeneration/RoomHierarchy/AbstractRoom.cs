using UnityEngine;

public abstract class AbstractRoom
{
    public enum Grid { FLOOR, WALL, EMPTY}

    public Vector2 roomPos;
    public Vector2 roomDir;

    protected int floorCount;

    protected abstract void InitializeRoom();

    protected abstract void GenerateFloor();

    protected abstract void GenerateWalls();

    protected Vector2 GetDirection()
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
