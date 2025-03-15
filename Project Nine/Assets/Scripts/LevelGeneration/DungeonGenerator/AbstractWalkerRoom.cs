using UnityEngine;
using System.Collections.Generic;

public abstract class AbstractWalkerRoom : AbstractRoom
{
    protected int maxWalkers;

    protected float fillPercent;

    protected List<Walker> walkerList;

    protected Grid[,] roomGrid = new Grid[32, 32];

    protected abstract void RemoveWalker();
    protected abstract void ChangeDirection();
    protected abstract void DuplicateWalker();
    protected abstract void UpdateWalkerPosition();
}
