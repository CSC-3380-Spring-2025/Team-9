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
        walkerList = new List<Walker>();
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

    public Vector2Int HallAlignmentUp(AbstractWalkerRoom roomTarget)
    {
        for (int y = roomGrid.GetLength(0) - 2; y >= 0; y--) // originally -1. 
        {
            for (int x = 1; x < roomGrid.GetLength(1); x++) // orginally x = 0.
            {
                if (roomGrid[x,y] == Grid.FLOOR)
                {
                    for (int y2 = 0; y2 < roomTarget.roomGrid.GetLength(0); y2++)
                    {
                        if (roomTarget.roomGrid[x ,y2] == Grid.FLOOR)
                        {
                            return new Vector2Int(x, y);
                        }
                    }
                }
            }
        }
        return Vector2Int.zero;
    }
    public Vector2Int HallAlignmentDown(AbstractWalkerRoom roomTarget)
    {
        for (int y = 1; y < roomGrid.GetLength(0); y++) // originally y = 0
        {
            for (int x = 1; x < roomGrid.GetLength(1); x++) // originally x = 0
            {
                if (roomGrid[x, y] == Grid.FLOOR)
                {
                    for (int y2 = 0; y2 < roomTarget.roomGrid.GetLength(0); y2++)
                    {
                        if (roomTarget.roomGrid[x, y2] == Grid.FLOOR)
                        {
                            return new Vector2Int(x, y);
                        }
                    }
                }
            }
        }
        return Vector2Int.zero;
    }
    public Vector2Int HallAlignmentLeft(AbstractWalkerRoom roomTarget)
    {
        for (int x = 1; x < roomGrid.GetLength(1); x++) // originally x = 0
        {
            for (int y = 1; y < roomGrid.GetLength(0); y++) // originally y = 0
            {
                if (roomGrid[x, y] == Grid.FLOOR)
                {
                    for (int x2 = 0; x2 < roomTarget.roomGrid.GetLength(1); x2++) // should i change this to start at 1 too?
                    {
                        if (roomTarget.roomGrid[x2, y] == Grid.FLOOR) 
                        {
                            return new Vector2Int(x, y);
                        }
                    }
                }
            }
        }
        return Vector2Int.zero;
    }
    public Vector2Int HallAlignmentRight(AbstractWalkerRoom roomTarget)
    {
        for (int x = roomGrid.GetLength(1) -2 ; x >= 0; x--) // originally -1
        {
            for (int y = 1; y < roomGrid.GetLength(0); y++) // originallly y = 0
            {
                if (roomGrid[x, y] == Grid.FLOOR)
                {
                    for (int x2 = 0; x2 < roomTarget.roomGrid.GetLength(1); x2++)
                    {
                        if (roomTarget.roomGrid[x2, y] == Grid.FLOOR) {return new Vector2Int(x,y);}
                    }
                }
            }
        }
        return Vector2Int.zero;
    }
    
    public void GenerateHallTopToBottom(AbstractWalkerRoom roomTarget)
    {
        Vector2Int tileVector1 = HallAlignmentUp(roomTarget);
        for (int y = tileVector1.y; y < roomGrid.GetLength(0); y++)
        {
            roomGrid[tileVector1.x, y] = Grid.FLOOR;

            if (roomGrid[tileVector1.x + 1, y] != Grid.FLOOR) {roomGrid[tileVector1.x + 1, y] = Grid.WALL; }
            if (roomGrid[tileVector1.x - 1, y] != Grid.FLOOR) { roomGrid[tileVector1.x - 1, y] = Grid.WALL; }
        }

        Vector2Int tileVector2 = new Vector2Int(tileVector1.x, 0);
        while (roomTarget.roomGrid[tileVector2.x, tileVector2.y] != Grid.FLOOR)
        {
            roomTarget.roomGrid[tileVector2.x, tileVector2.y] = Grid.FLOOR;

            if (roomTarget.roomGrid[tileVector2.x + 1, tileVector2.y] != Grid.FLOOR) { roomTarget.roomGrid[tileVector2.x + 1, tileVector2.y] = Grid.WALL; }
            if (roomTarget.roomGrid[tileVector2.x - 1, tileVector2.y] != Grid.FLOOR) { roomTarget.roomGrid[tileVector2.x - 1, tileVector2.y] = Grid.WALL; }
            tileVector2 = tileVector2 + Vector2Int.up;
        }

    }
    public void GenerateHallBottomToTop(AbstractWalkerRoom roomTarget)
    {
        Vector2Int tileVector1 = HallAlignmentDown(roomTarget);
        for (int y = tileVector1.y; y >= 0; y--)
        {
            roomGrid[tileVector1.x, y] = Grid.FLOOR;

            if (roomGrid[tileVector1.x + 1, y] != Grid.FLOOR) { roomGrid[tileVector1.x + 1, y] = Grid.WALL; }
            if (roomGrid[tileVector1.x - 1, y] != Grid.FLOOR) { roomGrid[tileVector1.x - 1, y] = Grid.WALL; }
        }
        Vector2Int tileVector2 = new Vector2Int(tileVector1.x, 31);

        while (roomTarget.roomGrid[tileVector2.x, tileVector2.y] != Grid.FLOOR)
        {
            roomTarget.roomGrid[tileVector2.x, tileVector2.y] = Grid.FLOOR;

            if (roomTarget.roomGrid[tileVector2.x + 1, tileVector2.y] != Grid.FLOOR) { roomTarget.roomGrid[tileVector2.x + 1, tileVector2.y] = Grid.WALL; }
            if (roomTarget.roomGrid[tileVector2.x - 1, tileVector2.y] != Grid.FLOOR) { roomTarget.roomGrid[tileVector2.x - 1, tileVector2.y] = Grid.WALL; }

            tileVector2 = tileVector2 + Vector2Int.down;
        }
    }
    public void GenerateHallLeftToRight(AbstractWalkerRoom roomTarget)
    {
        Vector2Int tileVector1 = HallAlignmentLeft(roomTarget);

        
        for (int x = tileVector1.x; x >= 0; x--)
        {
            roomGrid[x, tileVector1.y] = Grid.FLOOR;
            
            if (roomGrid[x, tileVector1.y + 1] != Grid.FLOOR) { roomGrid[x, tileVector1.y + 1] = Grid.WALL; }
            if (roomGrid[x, tileVector1.y - 1] != Grid.FLOOR) { roomGrid[x, tileVector1.y - 1] = Grid.WALL; }
        }

        Vector2Int tileVector2 = new Vector2Int(31, tileVector1.y);
        while (roomTarget.roomGrid[tileVector2.x, tileVector2.y] != Grid.FLOOR)
        {

            roomTarget.roomGrid[tileVector2.x, tileVector2.y] = Grid.FLOOR;

            
            if (roomTarget.roomGrid[tileVector2.x, tileVector2.y + 1] != Grid.FLOOR) { roomTarget.roomGrid[tileVector2.x, tileVector2.y + 1] = Grid.WALL; }
            if (roomTarget.roomGrid[tileVector2.x, tileVector2.y - 1] != Grid.FLOOR) { roomTarget.roomGrid[tileVector2.x, tileVector2.y - 1] = Grid.WALL; }
            tileVector2 = tileVector2 + Vector2Int.left;
        }
    }
    public void GenerateHallRightToLeft(AbstractWalkerRoom roomTarget)
    {
        Vector2Int tileVector1 = HallAlignmentRight(roomTarget);

        for (int x = tileVector1.x; x < roomGrid.GetLength(0); x++)
        {
            roomGrid[x, tileVector1.y] = Grid.FLOOR;

            if (roomGrid[x, tileVector1.y + 1] != Grid.FLOOR) { roomGrid[x, tileVector1.y + 1] = Grid.WALL; }
            if (roomGrid[x, tileVector1.y - 1] != Grid.FLOOR) { roomGrid[x, tileVector1.y - 1] = Grid.WALL; }
        }
        Vector2Int tileVector2 = new Vector2Int(0, tileVector1.y);

        while (roomTarget.roomGrid[tileVector2.x, tileVector2.y] != Grid.FLOOR)
        {
            roomTarget.roomGrid[tileVector2.x, tileVector2.y] = Grid.FLOOR;

            if (roomTarget.roomGrid[tileVector2.x, tileVector2.y + 1] != Grid.FLOOR) { roomTarget.roomGrid[tileVector2.x, tileVector2.y + 1] = Grid.WALL; }
            if (roomTarget.roomGrid[tileVector2.x, tileVector2.y - 1] != Grid.FLOOR) { roomTarget.roomGrid[tileVector2.x, tileVector2.y - 1] = Grid.WALL; }
            tileVector2 = tileVector2 + Vector2Int.right;
        }
    }
}