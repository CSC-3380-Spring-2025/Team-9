using System.Collections.Generic;
using UnityEngine;

public class Walker4rmChunk : Abstract4rmChunk
{
    public Walker4rmChunk()
    {
        SetChunkList();
        SetRoomPositions();
    }
    protected override void SetChunkList()
    {
        roomList = new List<AbstractRoom>();
        head = new WalkerRoom1x1();
        body1 = new WalkerRoom1x1();
        body2 = new WalkerRoom1x1();
        tail = new WalkerRoom1x1();

        roomList.Add(head);
        roomList.Add(body1);
        roomList.Add(body2);
        roomList.Add(tail);
    }
    public override void ScaleRoomPositions()
    {
        foreach (AbstractRoom room in roomList)
        {
            room.roomPos = room.roomPos * 32;
        }
    }
}