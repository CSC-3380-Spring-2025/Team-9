using UnityEngine;

public class DoorSpawn
{
    private Walker1x1ChunkLevel demoLevel;
    private Vector2 doorPosition;
    private GameObject doorInstance;
    public DoorSpawn(Walker1x1ChunkLevel dLevel, GameObject door)
    {
        demoLevel = dLevel;
        doorInstance = door;
        doorPosition = new Vector2((demoLevel.end.tail.roomGrid.GetLength(0) / 2) + .5f + demoLevel.end.tail.roomPos.x, (demoLevel.end.tail.roomGrid.GetLength(1) / 2) + .5f + demoLevel.end.tail.roomPos.y);
    }
    public void SetDoorPosition()
    {
        if (doorInstance != null)
        {
            doorInstance.transform.position = new Vector3(doorPosition.x, doorPosition.y, 0);
        }
        else
        {
            Debug.LogWarning("Door instance not set!");
        }
    }
}
