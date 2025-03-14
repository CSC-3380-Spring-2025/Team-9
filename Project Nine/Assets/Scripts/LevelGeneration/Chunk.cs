using UnityEngine;
using System.Collections.Generic;

public class Chunk
{
    //Rooms are created with specifying names to keep track of connections
    public Room head = new Room();
    public Room tail = new Room();
    public Room body1 = new Room();
    public Room body2 = new Room();

    //roomList is set up to store the following rooms in an iterable array
    public List<Room> roomList = new List<Room>();
    

    //chunkPosition and ChunkDirection are set up for keeping track of where in the level each chunk is pushed (all chunks start at zero)
    public Vector2 chunkPosition = Vector2.zero;
    public Vector2 ChunkDirection = Vector2.zero;
    
    /*
     * 
     */
    public Chunk()
    {
        SetChunk();
        GenerateHalls();
    }

    /*
     * This Method is responsible for the
     */
    private void SetChunk()
    { 
        head.roomDirection = Vector2.zero;

        roomList.Add(head);
        roomList.Add(body1);
        roomList.Add(body2);
        roomList.Add(tail);

        for (int i = 1; i < roomList.Count; i++)
        {
            roomList[i].roomPosition = roomList[i - 1].roomPosition;
            roomList[i].roomDirection = GetDirection();
            Vector2 oposite = roomList[i].roomDirection * -1;

            while (oposite.Equals(roomList[i - 1].roomDirection))
            {
                roomList[i].roomDirection = GetDirection();
                oposite = roomList[i].roomDirection * -1;
            }
            roomList[i].roomPosition = roomList[i].roomPosition + roomList[i].roomDirection;
        }
    }
    void GenerateHalls()
    {
        for (int i = roomList.Count - 1; i > 0; i--)
        {
            Vector2 connectionDirection;
            connectionDirection = roomList[i].roomDirection * -1;
            Vector2Int tileVector1;
            Vector2Int tileVector2;

            if (connectionDirection == Vector2.up)
            {
                tileVector1 = Chunk.HallAlignmentUp(roomList[i], roomList[i - 1]);
                for (int y = tileVector1.y; y < roomList[i].roomGrid.GetLength(0); y++)
                {
                    roomList[i].roomGrid[tileVector1.x, y] = Room.Grid.FLOOR;
                    if (roomList[i].roomGrid[tileVector1.x + 1, y] != Room.Grid.FLOOR) { roomList[i].roomGrid[tileVector1.x + 1, y] = Room.Grid.WALL; }
                    if (roomList[i].roomGrid[tileVector1.x - 1, y] != Room.Grid.FLOOR) { roomList[i].roomGrid[tileVector1.x - 1, y] = Room.Grid.WALL; }
                }
                tileVector2 = new Vector2Int(tileVector1.x, 0);
                while (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] != Room.Grid.FLOOR)
                {
                    roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] = Room.Grid.FLOOR;
                    if (roomList[i - 1].roomGrid[tileVector2.x + 1, tileVector2.y] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x + 1, tileVector2.y] = Room.Grid.WALL; }
                    if (roomList[i - 1].roomGrid[tileVector2.x - 1, tileVector2.y] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x - 1, tileVector2.y] = Room.Grid.WALL; }
                    tileVector2 = tileVector2 + Vector2Int.up;
                }

            }
            else if (connectionDirection == Vector2.down)
            {
                tileVector1 = Chunk.HallAlignmentDown(roomList[i], roomList[i - 1]);
                for (int y = tileVector1.y; y >= 0; y--)
                {
                    roomList[i].roomGrid[tileVector1.x, y] = Room.Grid.FLOOR;
                    if (roomList[i].roomGrid[tileVector1.x + 1, y] != Room.Grid.FLOOR) { roomList[i].roomGrid[tileVector1.x + 1, y] = Room.Grid.WALL; }
                    if (roomList[i].roomGrid[tileVector1.x - 1, y] != Room.Grid.FLOOR) { roomList[i].roomGrid[tileVector1.x - 1, y] = Room.Grid.WALL; }
                }
                tileVector2 = new Vector2Int(tileVector1.x, 31);
                while (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] != Room.Grid.FLOOR)
                {
                    roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] = Room.Grid.FLOOR;
                    if (roomList[i - 1].roomGrid[tileVector2.x + 1, tileVector2.y] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x + 1, tileVector2.y] = Room.Grid.WALL; }
                    if (roomList[i - 1].roomGrid[tileVector2.x - 1, tileVector2.y] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x - 1, tileVector2.y] = Room.Grid.WALL; }
               
                    tileVector2 = tileVector2 + Vector2Int.down;
                }
            }
            else if (connectionDirection == Vector2.left)
            {
                tileVector1 = Chunk.HallAlignmentLeft(roomList[i], roomList[i - 1]);
                for (int x = tileVector1.x; x >= 0; x--)
                {
                    roomList[i].roomGrid[x, tileVector1.y] = Room.Grid.FLOOR;
                    if (roomList[i].roomGrid[x, tileVector1.y + 1] != Room.Grid.FLOOR) { roomList[i].roomGrid[x, tileVector1.y + 1] = Room.Grid.WALL; }
                    if (roomList[i].roomGrid[x, tileVector1.y - 1] != Room.Grid.FLOOR) { roomList[i].roomGrid[x, tileVector1.y - 1] = Room.Grid.WALL; }
                }
                tileVector2 = new Vector2Int(31, tileVector1.y);
                while (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] != Room.Grid.FLOOR)
                {
                    roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] = Room.Grid.FLOOR;
                    if (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y + 1] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y + 1] = Room.Grid.WALL; }
                    if (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y - 1] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y - 1] = Room.Grid.WALL; }
                    tileVector2 = tileVector2 + Vector2Int.left;
                }
            }
            else if (connectionDirection == Vector2.right)
            {
                tileVector1 = Chunk.HallAlignmentRight(roomList[i], roomList[i - 1]);
                for (int x = tileVector1.x; x < roomList[i].roomGrid.GetLength(0); x++)
                {
                    roomList[i].roomGrid[x, tileVector1.y] = Room.Grid.FLOOR;
                    if (roomList[i].roomGrid[x, tileVector1.y + 1] != Room.Grid.FLOOR) { roomList[i].roomGrid[x, tileVector1.y + 1] = Room.Grid.WALL; }
                    if (roomList[i].roomGrid[x, tileVector1.y - 1] != Room.Grid.FLOOR) { roomList[i].roomGrid[x, tileVector1.y - 1] = Room.Grid.WALL; }
                }
                tileVector2 = new Vector2Int(0, tileVector1.y);
                while (roomList[i-1].roomGrid[tileVector2.x, tileVector2.y] != Room.Grid.FLOOR)
                {
                    roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] = Room.Grid.FLOOR;
                    if (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y + 1] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y + 1] = Room.Grid.WALL; }
                    if (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y - 1] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y - 1] = Room.Grid.WALL; }
                    tileVector2 = tileVector2 + Vector2Int.right;
                }
            }
        }
    }
    public void MoveChunk(Vector2 dir)
    {
        foreach (Room room in roomList)
        {
            room.roomPosition = room.roomPosition + dir;
        }
        chunkPosition = chunkPosition + dir;
    }
    public bool CheckCollision(Chunk chunk)
    {
        foreach(Room roomInstance in this.roomList)
        {
            foreach(Room roomComparison in chunk.roomList)
            {
                if (roomInstance.roomPosition.Equals(roomComparison.roomPosition))
                {
                    return true;
                }
            }
        }
        return false;
    }
    public Vector2 GetHeadPosition()
    {
        return head.roomPosition;
    }
    public Vector2 GetTailPosition()
    {
        return tail.roomPosition;
    }
    public Vector2 GetBody1Position()
    {
        return body1.roomPosition;
    }
    public Vector2 GetBody2Position()
    {
        return body2.roomPosition;
    }
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
    private static Vector2Int HallAlignmentUp(Room targetRoom, Room PrecedingRoom)
    {
        for(int y = targetRoom.roomGrid.GetLength(0) - 1; y >= 0; y-- )
        {
            for (int x = 0; x < targetRoom.roomGrid.GetLength(0); x++)
            {
                if (targetRoom.roomGrid[x, y] == Room.Grid.FLOOR)
                {
                    for(int y2 = 0; y2 < targetRoom.roomGrid.GetLength(0); y2++)
                    {
                        if(PrecedingRoom.roomGrid[x, y2] == Room.Grid.FLOOR)
                        {
                            return new Vector2Int(x, y);
                        }
                    }
                }
            }
        }
        return Vector2Int.zero;
    }
    private static Vector2Int HallAlignmentDown(Room targetRoom, Room PrecedingRoom)
    {
        for (int y = 0; y < targetRoom.roomGrid.GetLength(0); y++)
        {
            for (int x = 0; x < targetRoom.roomGrid.GetLength(0); x++)
            {
                if (targetRoom.roomGrid[x, y] == Room.Grid.FLOOR)
                {
                    for (int y2 = 0; y2 < targetRoom.roomGrid.GetLength(0); y2++)
                    {
                        if (PrecedingRoom.roomGrid[x, y2] == Room.Grid.FLOOR)
                        {
                            return new Vector2Int(x, y);
                        }
                    }
                }
            }
        }
        return Vector2Int.zero;
    }
    private static Vector2Int HallAlignmentLeft(Room targetRoom, Room PrecedingRoom)
    {
        for (int x = 0; x < targetRoom.roomGrid.GetLength(0); x++)
        {
            for (int y = 0; y < targetRoom.roomGrid.GetLength(0); y++)
            {
                if (targetRoom.roomGrid[x, y] == Room.Grid.FLOOR)
                {
                    for (int x2 = 0; x2 < targetRoom.roomGrid.GetLength(0); x2++)
                    {
                        if (PrecedingRoom.roomGrid[x2, y] == Room.Grid.FLOOR)
                        {
                            return new Vector2Int(x, y);
                        }
                    }
                }
            }
        }
        return Vector2Int.zero;
    }
    private static Vector2Int HallAlignmentRight(Room targetRoom, Room PrecedingRoom)
    {
        for (int x = targetRoom.roomGrid.GetLength(0) - 1; x >= 0; x--)
        {
            for (int y = 0; y < targetRoom.roomGrid.GetLength(0); y++)
            {
                if (targetRoom.roomGrid[x, y] == Room.Grid.FLOOR)
                {
                    for (int x2 = 0; x2 < targetRoom.roomGrid.GetLength(0); x2++)
                    {
                        if (PrecedingRoom.roomGrid[x2, y] == Room.Grid.FLOOR)
                        {
                            return new Vector2Int(x, y);
                        }
                    }
                }
            }
        }
        return Vector2Int.zero;
    }
}