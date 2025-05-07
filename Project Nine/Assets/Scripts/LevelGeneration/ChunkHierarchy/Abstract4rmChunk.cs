using UnityEngine;
using System.Collections.Generic;
public abstract class Abstract4rmChunk : AbstractChunk
{
    public abstract void GenerateHalls();
    protected abstract void SetChunkList();
    protected abstract void SetRoomPositions();
}