using UnityEngine;
using System.Collections.Generic;

public abstract class AbstractWalkerRoom : AbstractRoom
{
    protected int maxWalkers = 10;

    protected float fillPercent = .4f;

    public List<Walker> walkerList;

    public Grid[,] roomGrid = new Grid[32, 32];

    protected override void InitializeRoom()
    {
        for (int i = 0; i < roomGrid.GetLength(0); i++)
        {
            for (int j = 0; j < roomGrid.GetLength(1); j++)
            {
                roomGrid[i, j] = Grid.EMPTY;
            }
        }
        
        Vector2Int walkerPos = new Vector2Int(roomGrid.GetLength(0) / 2, roomGrid.GetLength(1) / 2);
        
        Walker curWalker = new Walker(walkerPos, GetDirection(), 0.5f);
        walkerList.Add(curWalker);
        roomGrid[walkerPos.x, walkerPos.y] = Grid.FLOOR;

        
        floorCount++;
    }
    protected override void GenerateWalls()
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

    protected abstract void RemoveWalker();
    protected abstract void ChangeDirection();
    protected abstract void DuplicateWalker();
    protected abstract void UpdateWalkerPosition();
}
