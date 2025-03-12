using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using System.Runtime.CompilerServices;

public class Room
{
    public enum Grid { FLOOR, WALL, EMPTY }
    public Grid[,] roomGrid = new Grid[32,32];
    public Vector2 roomDirection;
    public Vector2 roomPosition = new Vector2(0, 0);
    private int floorCount = 0;

    private int maxWalkers = 10;
    private int walkerHeight;
    private int walkerWidth;
    private float fillPercentage = .4f;

    private List<Walker> walkerList;

    public Room()
    {
        walkerWidth = 32;
        walkerHeight = 32;
        InitializeRoom();
        GenerateFloor();
        GenerateWalls();
    }

    private void InitializeRoom()
    {
        for (int i = 0; i < roomGrid.GetLength(0); i++)
        {
            for (int j = 0; j < roomGrid.GetLength(1); j++)
            {
                roomGrid[i, j] = Grid.EMPTY;
            }
        }
        walkerList = new List<Walker>();

        Vector2Int walkerPos = new Vector2Int((int)walkerHeight/2, (int)walkerWidth/2);

        Walker curWalker = new Walker(walkerPos, GetDirection(), 0.5f);

        walkerList.Add(curWalker);

        roomGrid[walkerPos.x, walkerPos.y] = Grid.FLOOR;

        floorCount++;
    }
    private void GenerateFloor()
    {
        while((float)floorCount/(float)((walkerHeight-2)*(walkerWidth-2)) < fillPercentage)
        {
            foreach (Walker walker in walkerList)
            {
                Vector2Int newWalkerPos = new Vector2Int((int)walker.Position.x, (int)walker.Position.y);
                if (roomGrid[newWalkerPos.x, newWalkerPos.y] != Grid.FLOOR)
                {
                    roomGrid[newWalkerPos.x, newWalkerPos.y] = Grid.FLOOR;
                    floorCount++;
                }
            }
            RemoveWalker();
            ChangeDirection();
            DuplicateWalker();
            UpdateWalkerPosition();
        }
    }
    private void GenerateWalls()
    {
        for (int i = 0; i < roomGrid.GetLength(0); i++)
        {
            for (int j = 0; j < roomGrid.GetLength(1); j++)
            {
                if (roomGrid[i, j] == Grid.FLOOR)
                {
                    if (roomGrid[i + 1, j] == Grid.EMPTY)
                    {
                        roomGrid[i + 1, j] = Grid.WALL;
                    }
                    if (roomGrid[i - 1, j] == Grid.EMPTY)
                    {
                        roomGrid[i - 1, j] = Grid.WALL;
                    }
                    if (roomGrid[i, j + 1] == Grid.EMPTY)
                    {
                        roomGrid[i, j + 1] = Grid.WALL;
                    }
                    if (roomGrid[i, j - 1] == Grid.EMPTY)
                    {
                        roomGrid[i, j - 1] = Grid.WALL;
                    }
                    if (roomGrid[i + 1, j + 1] == Grid.EMPTY)
                    {
                        roomGrid[i + 1, j + 1] = Grid.WALL;
                    }
                    if (roomGrid[i - 1, j - 1] == Grid.EMPTY)
                    {
                        roomGrid[i - 1, j - 1] = Grid.WALL;
                    }
                    if (roomGrid[i - 1, j + 1] == Grid.EMPTY)
                    {
                        roomGrid[i - 1, j + 1] = Grid.WALL;
                    }
                    if (roomGrid[i + 1, j - 1] == Grid.EMPTY)
                    {
                        roomGrid[i + 1, j - 1] = Grid.WALL;
                    }
                }
            }
        }
    }
    private void RemoveWalker()
    {
        int updatedCount = walkerList.Count;
        for (int i = 0; i < updatedCount; i++)
        {
            if (UnityEngine.Random.value < walkerList[i].chanceToChange && walkerList.Count > 1)
            {
                walkerList.RemoveAt(i);
                break;
            }
        }
    }
    private void ChangeDirection()
    {
        for (int i = 0; i < walkerList.Count; i++)
        {
            if (UnityEngine.Random.value < walkerList[i].chanceToChange)
            {
                Walker curWalker = walkerList[i];
                curWalker.Direction = GetDirection();
                walkerList[i] = curWalker;
            }
        }
    }
    private void DuplicateWalker()
    {
        int updateCount = walkerList.Count;
        for (int i = 0; i < updateCount; i++)
        {
            if (UnityEngine.Random.value < walkerList[i].chanceToChange && walkerList.Count < maxWalkers)
            {
                Vector2 newDirection = GetDirection();
                Vector2 newPosition = walkerList[i].Position;
                Walker newWalker = new Walker(newPosition, newDirection, 0.5f);
                walkerList.Add(newWalker);
            }
        }
    }
    private void UpdateWalkerPosition()
    {
        for (int i = 0; i < walkerList.Count; i++)
        {
            Walker foundWalker = walkerList[i];
            foundWalker.Position += foundWalker.Direction;
            foundWalker.Position.x = Mathf.Clamp(foundWalker.Position.x, 1, walkerHeight - 2);
            foundWalker.Position.y = Mathf.Clamp(foundWalker.Position.y, 1, walkerWidth - 2);
            walkerList[i] = foundWalker;
        }
    }
    private Vector2 GetDirection()
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
    public Vector2Int GetDownMostFloor()
    {
        for(int y = 0; y < roomGrid.GetLength(0); y++)
        {
            for (int x = 0; x < roomGrid.GetLength(1); x++)
            {
                if (roomGrid[x, y] == Grid.FLOOR)
                    return new Vector2Int(x,y);
            }
        }
        return Vector2Int.zero;
    }
    public Vector2Int GetUpMostFloor()
    {
        for (int y = roomGrid.GetLength(0)-1; y >= 0; y--)
        {
            for (int x = 0; x < roomGrid.GetLength(1); x++)
            {
                if (roomGrid[x, y] == Grid.FLOOR)
                    return new Vector2Int(x, y);
            }
        }
        return Vector2Int.zero;
    }
    public Vector2Int GetLeftMostFloor()
    {
        for (int x = 0; x < roomGrid.GetLength(1); x++)
        {
            for (int y = 0; y < roomGrid.GetLength(0); y++)
            {
                if (roomGrid[x, y] == Grid.FLOOR)
                    return new Vector2Int(x, y);
            }
        }
        return Vector2Int.zero;
    }
    public Vector2Int GetRightMostFloor()
    {
        for (int x = roomGrid.GetLength(0) - 1; x >= 0; x--)
        {
            for (int y = 0; y < roomGrid.GetLength(1); y++)
            {
                if (roomGrid[x, y] == Grid.FLOOR)
                    return new Vector2Int(x, y);
            }
        }
        return Vector2Int.zero;
    }
}