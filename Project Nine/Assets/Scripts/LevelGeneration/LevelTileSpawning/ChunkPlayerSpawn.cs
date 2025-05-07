using UnityEngine;

public class ChunkPlayerSpawn
{
    public Walker4rmChunk demoLevel;
    private Vector2 playerPosition;
    private GameObject playerInstance;

    public ChunkPlayerSpawn(Walker4rmChunk dLevel, GameObject player)
    {
        demoLevel = dLevel;
        playerInstance = player;
        playerPosition = new Vector2((demoLevel.head.roomGrid.GetLength(0) / 2) + .5f, (demoLevel.head.roomGrid.GetLength(1) / 2) + .5f);
        //playerPosition = playerPosition * new Vector2(demoLevel.head.roomPos.x, demoLevel.head.roomPos.y);
    }

    public void SetPlayerPosition()
    {
        if (playerInstance != null)
        {
            playerInstance.transform.position = new Vector3(playerPosition.x, playerPosition.y, 0);
        }
        else
        {
            Debug.LogWarning("Player instance not set!");
        }
    }
}
