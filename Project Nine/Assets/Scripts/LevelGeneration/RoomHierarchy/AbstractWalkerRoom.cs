using UnityEngine;
using System.Collections.Generic;

public abstract class AbstractWalkerRoom : AbstractRoom, IConnection<AbstractWalkerRoom>
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

    public Vector2 CheckConnectionDirection(AbstractWalkerRoom roomTarget)
    {
        return Vector2.zero;
    }

    public Vector2 HallAlignmentUp(AbstractWalkerRoom roomTarget)
    {
        for (int y = roomGrid.GetLength(0) - 1; y >= 0; y--)
        {
            for (int x = 0; x < roomGrid.GetLength(1); x++)
            {
                if (roomGrid[x,y] == Grid.FLOOR)
                {
                    for (int y2 = 0; y2 < roomTarget.roomGrid.GetLength(0); x++)
                    {
                        if (roomTarget.roomGrid[x,y2] == Grid.FLOOR)
                        {
                            return new Vector2(x, y);
                        }
                    }
                }
            }
        }
        return Vector2.zero;
    }
    public Vector2 HallAlignmentDown(AbstractWalkerRoom roomTarget)
    {
        for (int y = 0; y < roomGrid.GetLength(0); y++)
        {
            for (int x = 0; x < roomGrid.GetLength(1); x++)
            {
                if (roomGrid[x, y] == Grid.FLOOR)
                {
                    for (int y2 = 0; y2 < roomTarget.roomGrid.GetLength(0); y2++)
                    {
                        if (roomGrid[x, y2] == Grid.FLOOR)
                        {
                            return new Vector2(x, y);
                        }
                    }
                }
            }
        }
        return Vector2.zero;
    }
    public Vector2 HallAlignmentLeft(AbstractWalkerRoom roomTarget)
    {
        for (int x = 0; x < roomGrid.GetLength(1); x++)
        {
            for (int y = 0; y < roomGrid.GetLength(0); y++)
            {
                if (roomGrid[x, y] == Grid.FLOOR)
                {
                    for (int x2 = 0; x2 < roomTarget.roomGrid.GetLength(1); x2++)
                    {
                        if (roomTarget.roomGrid[x2, y] == Grid.FLOOR)
                        {
                            return new Vector2(x, y);
                        }
                    }
                }
            }
        }
        return Vector2.zero;
    }
    public Vector2 HallAlignmentRight(AbstractWalkerRoom roomTarget)
    {
        for (int x = roomGrid.GetLength(1) -1; x >= 0; x--)
        {
            for (int y = 0; y < roomGrid.GetLength(0); y++)
            {
                if (roomGrid[x, y] == Grid.FLOOR)
                {
                    for (int x2 = 0; x2 < roomTarget.roomGrid.GetLength(1); x2++)
                    {
                        if (roomTarget.roomGrid[x2, y] == Grid.FLOOR) {return new Vector2(x,y);}
                    }
                }
            }
        }
        return Vector2.zero;
    }
    
    public void GenerateHallTopToBottom(AbstractWalkerRoom roomTarget)
    {

    }
    public void GenerateHallBottomToTop(AbstractWalkerRoom roomTarget)
    {

    }
    public void GenerateHallLeftToRight(AbstractWalkerRoom roomTarget)
    {

    }
    public void GenerateHallRightToLeft(AbstractWalkerRoom roomTarget)
    {

    }
}
