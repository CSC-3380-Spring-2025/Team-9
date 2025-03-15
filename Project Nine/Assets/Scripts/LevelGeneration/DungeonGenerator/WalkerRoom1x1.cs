using UnityEngine;

public class WalkerRoom1x1 : AbstractWalkerRoom
{

    public WalkerRoom1x1()
    {
        InitializeRoom();
        GenerateFloor();
        GenerateWalls();
    }

    protected override void GenerateFloor()
    {
        while ((float)floorCount / (int) roomGrid.Length < fillPercent)
        {
            
            foreach (Walker walker in walkerList)
            {
                Vector2Int newWalkerPos = new Vector2Int((int)walker.Position.x, (int)walker.Position.y);
                if (roomGrid[newWalkerPos.x, newWalkerPos.y] != Grid.FLOOR)
                {
                    roomGrid[newWalkerPos.x, newWalkerPos.y] = Grid.FLOOR;
                    floorCount++;
                }
            }
            RemoveWalker();
            ChangeDirection();
            DuplicateWalker();
            UpdateWalkerPosition();
        }
    }

    protected override void RemoveWalker()
    {
        int updatedCount = walkerList.Count;
        for (int i = 0; i < updatedCount; i++)
        {
            if (UnityEngine.Random.value < walkerList[i].chanceToChange && walkerList.Count > 1)
            {
                walkerList.RemoveAt(i);
                break;
            }
        }
    }
    protected override void ChangeDirection()
    {
        for (int i = 0; i < walkerList.Count; i++)
        {
            if (UnityEngine.Random.value < walkerList[i].chanceToChange)
            {
                Walker curWalker = walkerList[i];
                curWalker.Direction = GetDirection();
                walkerList[i] = curWalker;
            }
        }
    }
    protected override void DuplicateWalker()
    {
        int updateCount = walkerList.Count;
        for (int i = 0; i < updateCount; i++)
        {
            if (UnityEngine.Random.value < walkerList[i].chanceToChange && walkerList.Count < maxWalkers)
            {
                Vector2 newDirection = GetDirection();
                Vector2 newPosition = walkerList[i].Position;
                Walker newWalker = new Walker(newPosition, newDirection, 0.5f);
                walkerList.Add(newWalker);
            }
        }
    }
    protected override void UpdateWalkerPosition()
    {
        for (int i = 0; i < walkerList.Count; i++)
        {
            Walker foundWalker = walkerList[i];
            foundWalker.Position += foundWalker.Direction;
            foundWalker.Position.x = Mathf.Clamp(foundWalker.Position.x, 1, roomGrid.GetLength(0) - 2);
            foundWalker.Position.y = Mathf.Clamp(foundWalker.Position.y, 1, roomGrid.GetLength(1) - 2);
            walkerList[i] = foundWalker;
        }
    }
}
