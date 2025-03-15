using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    //tilemap is the initialized tilemap that level tiles will be initiated on
    public Tilemap tilemap;

    //wall, and floor are public tiles that can be selected to be placed instead of the enum WALL and FLOOR
    public Tile wall;
    public Tile floor;

    //keeps track of num tiles for fun
    public int tileCount = default;

    /*
     * This Method is responsible for the placement of tiles
     */
    public void PlaceTiles()
    {
        //Initializes a new level
        Level level = new Level();

        //clears all tilemaps before adding new ones (+set tilecount to default)
        tilemap.ClearAllTiles();
        tileCount = default;

        //outer foreach loop iterates through all chunks in the level
        foreach (Chunk chunk in level.chunkList)
        {
            //inner foreach loop iterates through all rooms in the cur chunk
            foreach (Room room in chunk.roomList)
            {
                CycleRoom(room);
            }
        }
    }
    private void CycleRoom(Room room)
    {
        //location initialization for indevidual room tileplacemtn
        Vector3Int initialTilePlacer = new Vector3Int((int)room.roomPosition.x, (int)room.roomPosition.y, 0);

        //nested for loop iterates throough each position in a 2-D enum Grid[,] for the cur room
        for (int i = 0; i < room.roomGrid.GetLength(0); i++)
        {
            for (int j = 0; j < room.roomGrid.GetLength(1); j++)
            {
                Vector3Int tilePlacer = new Vector3Int(initialTilePlacer.x + i, initialTilePlacer.y + j, 0);

                //checks to see if the Grid enum in the room is set to floor
                if (room.roomGrid[i, j] == Room.Grid.FLOOR)
                {
                    //places floor tile and adds to tilecount
                    tilemap.SetTile(tilePlacer, floor);
                    tileCount++;
                }
                //checks if the Grid enum in the room is set to wall
                if (room.roomGrid[i, j] == Room.Grid.WALL)
                {
                    //places wall tile
                    tilemap.SetTile(tilePlacer, wall);
                }
            }
        }
    }
}