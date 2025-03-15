using UnityEngine;

public abstract class AbstractRoom
{
    public enum Grid { FLOOR, WALL, EMPTY}

    public Vector2Int roomPos;
    public Vector2Int roomDir;

    public int floorCount;

    public abstract void InitializeRoom();

    public abstract void GenerateFloor();

    public abstract void GenerateWalls();

}
