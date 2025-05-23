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
     * Createion for Chunk object
     * 
     * @stepts:
     * a) SetChunk()
     * b) GenerateWalls()
     */
    public Chunk()
    {
        SetChunk();
        GenerateHalls();
    }

    /*
     * This Method is responsible for adding rooms together and moving each room till there are no collisions between rooms
     * Additionally the room sets the position of each room
     */
    private void SetChunk()
    { 
        //Sets the head room dir to (0,0)
        head.roomDirection = Vector2.zero;

        //lines 42-46: adds the rooms of chunk to the roomList 
        roomList.Add(head);
        roomList.Add(body1);
        roomList.Add(body2);
        roomList.Add(tail);

        //Outer for loop beggins at body1 (head room will not move) and sets the position of the rooms with continuity
        for (int i = 1; i < roomList.Count; i++)
        {
            //sets the position of the next room to position of the last
            roomList[i].roomPosition = roomList[i - 1].roomPosition;

            //gives new dir to the curr room
            roomList[i].roomDirection = GetDirection();
            Vector2 oposite = roomList[i].roomDirection * -1;

            //inner while loop checks the direction of the previous room so that the new direction of the cur room will not move back over the prev room
            while (oposite.Equals(roomList[i - 1].roomDirection))
            {
                roomList[i].roomDirection = GetDirection();
                oposite = roomList[i].roomDirection * -1;
            }
            roomList[i].roomPosition = roomList[i].roomPosition + roomList[i].roomDirection;
        }
    }

    /*
     * This Method is responsible for the generation of halls between rooms and chunks
     * (by far the worst method I have ever written, needs to be replaced BAD)
     * 
     */
    private void GenerateHalls()
    {
        //Most outer loop is responsible for working backwards within the room list to set the halls of the rooms
        for (int i = roomList.Count - 1; i > 0; i--)
        {
            //ConnectionDirection points in the direction of the previous room
            Vector2 connectionDirection = roomList[i].roomDirection * -1;

            //the tileVectors are responsible for setting up the positions in which the floor/wall tiles will be placed
            Vector2Int tileVector1;
            Vector2Int tileVector2;

            //if the previous room is the above the cur room then...
            if (connectionDirection == Vector2.up)
            {
                //tileVector is set to an appropriate position with the AlignmentUp method
                tileVector1 = Chunk.HallAlignmentUp(roomList[i], roomList[i - 1]);

                //for loop is responsible for placing tiles in the cur room
                for (int y = tileVector1.y; y < roomList[i].roomGrid.GetLength(0); y++)
                {
                    //FLOOR is placed
                    roomList[i].roomGrid[tileVector1.x, y] = Room.Grid.FLOOR;

                    //both if methods check the tiles next to the new FLOOR tiles to place a WALL
                    if (roomList[i].roomGrid[tileVector1.x + 1, y] != Room.Grid.FLOOR) { roomList[i].roomGrid[tileVector1.x + 1, y] = Room.Grid.WALL; }
                    if (roomList[i].roomGrid[tileVector1.x - 1, y] != Room.Grid.FLOOR) { roomList[i].roomGrid[tileVector1.x - 1, y] = Room.Grid.WALL; }
                }
                tileVector2 = new Vector2Int(tileVector1.x, 0);

                //while loop is responsible for setting the tiles in the next room
                while (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] != Room.Grid.FLOOR)
                {
                    //FLOOR is placed
                    roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] = Room.Grid.FLOOR;

                    //both if methods check the tiles next to the new FLOOR tiles to place a WALL
                    if (roomList[i - 1].roomGrid[tileVector2.x + 1, tileVector2.y] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x + 1, tileVector2.y] = Room.Grid.WALL; }
                    if (roomList[i - 1].roomGrid[tileVector2.x - 1, tileVector2.y] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x - 1, tileVector2.y] = Room.Grid.WALL; }
                    tileVector2 = tileVector2 + Vector2Int.up;
                }

            }
            //if the previous room is the below the cur room then...
            else if (connectionDirection == Vector2.down)
            {
                tileVector1 = Chunk.HallAlignmentDown(roomList[i], roomList[i - 1]);

                //for loop is responsible for placing tiles in the cur room
                for (int y = tileVector1.y; y >= 0; y--)
                {
                    //FLOOR is placed
                    roomList[i].roomGrid[tileVector1.x, y] = Room.Grid.FLOOR;

                    //both if methods check the tiles next to the new FLOOR tiles to place a WALL
                    if (roomList[i].roomGrid[tileVector1.x + 1, y] != Room.Grid.FLOOR) { roomList[i].roomGrid[tileVector1.x + 1, y] = Room.Grid.WALL; }
                    if (roomList[i].roomGrid[tileVector1.x - 1, y] != Room.Grid.FLOOR) { roomList[i].roomGrid[tileVector1.x - 1, y] = Room.Grid.WALL; }
                }
                tileVector2 = new Vector2Int(tileVector1.x, 31);

                //while loop is responsible for setting the tiles in the next room
                while (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] != Room.Grid.FLOOR)
                {
                    //FLOOR is placed
                    roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] = Room.Grid.FLOOR;

                    //both if methods check the tiles next to the new FLOOR tiles to place a WALL
                    if (roomList[i - 1].roomGrid[tileVector2.x + 1, tileVector2.y] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x + 1, tileVector2.y] = Room.Grid.WALL; }
                    if (roomList[i - 1].roomGrid[tileVector2.x - 1, tileVector2.y] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x - 1, tileVector2.y] = Room.Grid.WALL; }
               
                    tileVector2 = tileVector2 + Vector2Int.down;
                }
            }
            //if the previous room is the left of the cur room then...
            else if (connectionDirection == Vector2.left)
            {
                tileVector1 = Chunk.HallAlignmentLeft(roomList[i], roomList[i - 1]);

                //for loop is responsible for placing tiles in the cur room
                for (int x = tileVector1.x; x >= 0; x--)
                {
                    //FLOOR is placed
                    roomList[i].roomGrid[x, tileVector1.y] = Room.Grid.FLOOR;

                    //both if methods check the tiles next to the new FLOOR tiles to place a WALL
                    if (roomList[i].roomGrid[x, tileVector1.y + 1] != Room.Grid.FLOOR) { roomList[i].roomGrid[x, tileVector1.y + 1] = Room.Grid.WALL; }
                    if (roomList[i].roomGrid[x, tileVector1.y - 1] != Room.Grid.FLOOR) { roomList[i].roomGrid[x, tileVector1.y - 1] = Room.Grid.WALL; }
                }
                tileVector2 = new Vector2Int(31, tileVector1.y);

                //while loop is responsible for setting the tiles in the next room
                while (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] != Room.Grid.FLOOR)
                {
                    //FLOOR is placed
                    roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] = Room.Grid.FLOOR;

                    //both if methods check the tiles next to the new FLOOR tiles to place a WALL
                    if (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y + 1] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y + 1] = Room.Grid.WALL; }
                    if (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y - 1] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y - 1] = Room.Grid.WALL; }
                    tileVector2 = tileVector2 + Vector2Int.left;
                }
            }
            //if the previous room is the right the cur room then...
            else if (connectionDirection == Vector2.right)
            {
                tileVector1 = Chunk.HallAlignmentRight(roomList[i], roomList[i - 1]);

                //for loop is responsible for placing tiles in the cur room
                for (int x = tileVector1.x; x < roomList[i].roomGrid.GetLength(0); x++)
                {
                    //FLOOR is placed
                    roomList[i].roomGrid[x, tileVector1.y] = Room.Grid.FLOOR;

                    //both if methods check the tiles next to the new FLOOR tiles to place a WALL
                    if (roomList[i].roomGrid[x, tileVector1.y + 1] != Room.Grid.FLOOR) { roomList[i].roomGrid[x, tileVector1.y + 1] = Room.Grid.WALL; }
                    if (roomList[i].roomGrid[x, tileVector1.y - 1] != Room.Grid.FLOOR) { roomList[i].roomGrid[x, tileVector1.y - 1] = Room.Grid.WALL; }
                }
                tileVector2 = new Vector2Int(0, tileVector1.y);

                //while loop is responsible for setting the tiles in the next room
                while (roomList[i-1].roomGrid[tileVector2.x, tileVector2.y] != Room.Grid.FLOOR)
                {
                    //FLOOR is placed
                    roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y] = Room.Grid.FLOOR;

                    //both if methods check the tiles next to the new FLOOR tiles to place a WALL
                    if (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y + 1] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y + 1] = Room.Grid.WALL; }
                    if (roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y - 1] != Room.Grid.FLOOR) { roomList[i - 1].roomGrid[tileVector2.x, tileVector2.y - 1] = Room.Grid.WALL; }
                    tileVector2 = tileVector2 + Vector2Int.right;
                }
            }
        }
    }
    
    /*
     * This Method is reponsible for moving all rooms withing a chunk, the chunk itself, and updating all positions
     * 
     * @param Vector2 dir, responsible for determining the direction that the room/chunk will move in
     */
    public void MoveChunk(Vector2 dir)
    {
        foreach (Room room in roomList)
        {
            room.roomPosition = room.roomPosition + dir;
        }
        chunkPosition = chunkPosition + dir;
    }
    
    /*
     * This Method is used to check the collisions between chunks
     * 
     * @param Chunk chunk, is checked against the use case chunk to check for collisions of rooms within both chunks
     * 
     * 
     */
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

    /*
     * Method for arbitrating a random direction
     * 
     * @return Vector2.up,down,left,right
     */
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

    /*
     * This Method is responsible for connecting halls where the prev room is above the target
     * 
     * @param Room targetRoom, is used to compare where a position most extreme position for connecting to the preceding room
     * @param Room PrecedingRoom, checked for a plausible location for connection
     */
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

    /*
    * This Method is responsible for connecting halls where the prev room is bellow the target
    * 
    * @param Room targetRoom, is used to compare where a position most extreme position for connecting to the preceding room
    * @param Room PrecedingRoom, checked for a plausible location for connection
    */
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

    /*
    * This Method is responsible for connecting halls where the prev room is left the target
    * 
    * @param Room targetRoom, is used to compare where a position most extreme position for connecting to the preceding room
    * @param Room PrecedingRoom, checked for a plausible location for connection
    */
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

    /*
    * This Method is responsible for connecting halls where the prev room is right the target
    * 
    * @param Room targetRoom, is used to compare where a position most extreme position for connecting to the preceding room
    * @param Room PrecedingRoom, checked for a plausible location for connection
    */
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