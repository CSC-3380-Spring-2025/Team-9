using UnityEngine;
using System.Collections.Generic;

public class Room
{
    //This Enum is designed to store FLOOR WALL and EMPTY tile locations for each room
    public enum Grid { FLOOR, WALL, EMPTY }
    //roomGrid is a 2-D array that sets up an array for the enums can be placed in
    public Grid[,] roomGrid = new Grid[32,32];

    //roomDirection and roomPosition is used later by Chunk classes to keep track of collisions of rooms
    public Vector2 roomDirection;
    public Vector2 roomPosition = new Vector2(0, 0);

    //floorCount is created to confirm when to stop the placement of tiles in the room
    private int floorCount = 0;

    //maxWalkers keeps the num of walkers to a certain value (can effect the look of a room)
    private int maxWalkers = 10;

    private int walkerHeight = 32;
    private int walkerWidth = 32;

    //fillPercentage is checked against floorCount devided by total num of titles (to know when to stop placing FLOOR tiles)
    private float fillPercentage = .4f;

    //walkerList is used to inumerat through all created walkers and move through all 
    private List<Walker> walkerList = new List<Walker>();



    //Creation for Room object
    /*
     * @steps:
     * a) InitializeRoom()
     * b) GenerateFloor()
     * c) GenerateWalls()
     * 
     * no @param needed
     */
    public Room()
    {
        InitializeRoom();
        GenerateFloor();
        GenerateWalls();
    }

    //1st function of the walker algorithm: removes walker
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
    //2nd function of walker algorithm: changes focus direction of a walker
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
    //3rd function of walker algorithm: duplicates walker
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
    //4th function of walker algorithm: pushes walker position one space in direction
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
    /*
     * This Method is responsible for setting the position of a walker to the middle of the room
     * Additionally, the enum Grid[,] is set entirely to empty  
     */
    private void InitializeRoom()
    {
        //Nested Loop sets all enum Grid[,] positions to EMPTY
        for (int i = 0; i < roomGrid.GetLength(0); i++)
        {
            for (int j = 0; j < roomGrid.GetLength(1); j++)
            {
                roomGrid[i, j] = Grid.EMPTY;
            }
        }
        //walkerPos is the initialPosition of the first walker (middle of enum Grid[,])
        Vector2Int walkerPos = new Vector2Int((int)walkerHeight/2, (int)walkerWidth/2);
        
        //curWalker first walker added to walker list and at its position a floor tile is placed
        Walker curWalker = new Walker(walkerPos, GetDirection(), 0.5f);
        walkerList.Add(curWalker);
        roomGrid[walkerPos.x, walkerPos.y] = Grid.FLOOR;

        //add 1 tile
        floorCount++;
    }
    
    /*
     * This Method is responsible for checking the curFloorPercentage is < fillPercentage and employing the walker algorithm
     * Employs:
     * a) RemoveWalker()
     * b) ChangeDirection()
     * c) DuplicateWalker()
     * d) UpdateWalkerPosition()
     */
    private void GenerateFloor()
    {
        //Outerloop responsible for checking if the number of tiles placed/the max numbers is less than fillPercentage
        while((float)floorCount/(float)((walkerHeight-2)*(walkerWidth-2)) < fillPercentage)
        {
            //Inner loop responsible for enumerating through the walker list and running walkerAlg
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

    /*
     * This Method generates walls surrounding each floor tile on all nextTo and adjacent tiles
     */
    private void GenerateWalls()
    {
        //Nested loop checks every position in enum Grid[,]
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
    /*
     * This Method returns an up,down,left, or right Vector direction
     * 
     * @returns a Vector2 value
     */
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
}