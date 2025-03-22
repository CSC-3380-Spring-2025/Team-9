using UnityEngine;
using System.Collections.Generic;

public class Walker1x1ChunkLevel
{
    public Walker4rmChunk start = new Walker4rmChunk();
    public Walker4rmChunk end = new Walker4rmChunk();
    public Walker4rmChunk pivot = new Walker4rmChunk();
    public Walker4rmChunk extra = new Walker4rmChunk();

    public List<Walker4rmChunk> chunkList;
    
    public Walker1x1ChunkLevel()
    {
        SetChunkList();
        PositionChunks();
        StartPivotHallway();
        EndPivotHallway();
        ScaleRoomPositions();
    }
    private void SetChunkList()
    {
        chunkList = new List<Walker4rmChunk>();

        chunkList.Add(start);
        chunkList.Add(end);
        chunkList.Add(pivot);
        chunkList.Add(extra);
    }
    private void PositionChunks()
    {
        Vector2 dir = AbstractChunk.GetDirection();

        start.chunkDirection = dir;
        while (start.CheckCollision(pivot))
        {
            start.MoveChunk(start.chunkDirection);
        }
        end.chunkDirection = dir * -1;
        while (end.CheckCollision(pivot) || end.CheckCollision(start))
        {
            end.MoveChunk(end.chunkDirection);
        }
        extra.chunkDirection = AbstractChunk.GetDirection();
        while (extra.CheckCollision(pivot) || extra.CheckCollision(start) || extra.CheckCollision(end))
        {
            extra.MoveChunk(extra.chunkDirection);
        }
    }
    public void ScaleRoomPositions()
    {
        foreach (Walker4rmChunk chunk in chunkList)
        {
            foreach (WalkerRoom1x1 room in chunk.roomList)
            {
                room.roomPos = room.roomPos * 32;
            }
        }
    }
    private void EndPivotHallway()
    {
        foreach (WalkerRoom1x1 roomS in end.roomList)
        {
            foreach (WalkerRoom1x1 roomP in pivot.roomList)
            {
                Vector2[] offset ={
                    new Vector2(1,0),
                    new Vector2(0,1),
                    new Vector2(-1,0),
                    new Vector2(0,-1),};
                foreach (Vector2 vector in offset)
                {
                    if (roomS.roomPos + vector == roomP.roomPos)
                    {
                        if (vector == Vector2.up)
                        {
                            roomS.GenerateHallTopToBottom(roomP);
                            return;
                        }
                        if (vector == Vector2.down)
                        {
                            roomS.GenerateHallBottomToTop(roomP);
                            return;
                        }
                        if (vector == Vector2.left)
                        {
                            roomS.GenerateHallLeftToRight(roomP);
                            return;
                        }
                        if (vector == Vector2.right)
                        {
                            roomS.GenerateHallRightToLeft(roomP);
                            return;
                        }
                    }
                }
            }
        }
    }
    private void StartPivotHallway()
    {
        foreach(WalkerRoom1x1 roomS in start.roomList)
        {
            foreach(WalkerRoom1x1 roomP in pivot.roomList)
            {
                Vector2[] offset ={
                    new Vector2(1,0),
                    new Vector2(0,1),
                    new Vector2(-1,0),
                    new Vector2(0,-1),};
                foreach(Vector2 vector in offset)
                {
                    if(roomS.roomPos + vector == roomP.roomPos)
                    {
                        if(vector == Vector2.up)
                        {
                            roomS.GenerateHallTopToBottom(roomP);
                            return;
                        }
                        if(vector == Vector2.down)
                        {
                            roomS.GenerateHallBottomToTop(roomP);
                            return;
                        }
                        if (vector == Vector2.left)
                        {
                            roomS.GenerateHallLeftToRight(roomP);
                            return;
                        }
                        if (vector == Vector2.right)
                        {
                            roomS.GenerateHallRightToLeft(roomP);
                            return;
                        }
                    }
                }
            }
        }
    }
}
