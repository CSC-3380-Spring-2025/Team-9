using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LightTransport.PostProcessing;

public class Walker4rmChunk : Abstract4rmChunk
{
    public List<WalkerRoom1x1> roomList;
    public WalkerRoom1x1 head = new WalkerRoom1x1();
    public WalkerRoom1x1 body1 = new WalkerRoom1x1();
    public WalkerRoom1x1 body2 = new WalkerRoom1x1();
    public WalkerRoom1x1 tail = new WalkerRoom1x1();
    public Walker4rmChunk()
    {
        SetChunkList();
        SetRoomPositions();
        GenerateHalls();
    }
    protected override void SetChunkList()
    {
        roomList = new List<WalkerRoom1x1>();

        roomList.Add(head);
        roomList.Add(body1);
        roomList.Add(body2);
        roomList.Add(tail);
    }
    public override void GenerateHalls()
    {
        for (int i = roomList.Count -1; i >= 1; i--)
        {
            Vector2 connectionDirection = roomList[i].roomDir * -1;

            if (connectionDirection == Vector2.up)
            {
                roomList[i].GenerateHallTopToBottom(roomList[i-1]);
            }
            else if (connectionDirection == Vector2.down)
            {
                roomList[i].GenerateHallBottomToTop(roomList[i-1]);
            }
            else if (connectionDirection == Vector2.left)
            {
                roomList[i].GenerateHallLeftToRight(roomList[i-1]);
            }
            else if (connectionDirection == Vector2.right)
            {
                roomList[i].GenerateHallRightToLeft(roomList[i - 1]);
            }
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
    public override void ScaleRoomPositions()
    {
        foreach (AbstractRoom room in roomList)
        {
            room.roomPos = room.roomPos * 32;
        }
    }
    protected override void SetRoomPositions()
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
    

}