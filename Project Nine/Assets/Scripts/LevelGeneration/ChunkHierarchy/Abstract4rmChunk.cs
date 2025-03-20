using UnityEngine;
using System.Collections.Generic;
public abstract class Abstract4rmChunk : AbstractChunk
{
    public AbstractRoom head;
    public AbstractRoom tail;
    public AbstractRoom body1;
    public AbstractRoom body2;

    public List<AbstractRoom> roomList;
    protected abstract void SetChunkList();
    protected void SetRoomPositions()
    {
        for (int i = 1; i < roomList.Count; i++)
        {
            roomList[i].roomPos = roomList[i - 1].roomPos;

            roomList[i].roomDir = GetDirection();
            Vector2 oposite = roomList[i].roomDir * -1;

            while (oposite.Equals(roomList[i - 1].roomDir))
            {
                roomList[i].roomDir = GetDirection();
                oposite = roomList[i].roomDir * -1;
            }
            roomList[i].roomPos = roomList[i].roomPos + roomList[i].roomDir;
        }
    }
    protected override void MoveChunk(Vector2Int dir)
    {
        foreach (AbstractRoom room in roomList)
        {
            room.roomPos = room.roomPos + dir;
        }
        chunkPosition = chunkPosition + dir;
    }
}