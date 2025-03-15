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
        head = new WalkerRoom1x1();
        body1 = new WalkerRoom1x1();
        body2 = new WalkerRoom1x1();
        tail = new WalkerRoom1x1();

        roomList.Add(head);
        roomList.Add(body1);
        roomList.Add(body2);
        roomList.Add(tail);
    }
}
