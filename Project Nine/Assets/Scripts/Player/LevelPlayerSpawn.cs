using UnityEngine;

public class LevelPlayerSpawn
{
    public Walker1x1ChunkLevel demoLevel;
    public Vector2 playerPosition;
    private GameObject playerInstance;

    public LevelPlayerSpawn(Walker1x1ChunkLevel dLevel, GameObject player)
    {
        demoLevel = dLevel;
        playerInstance = player;
        playerPosition = new Vector2((demoLevel.start.head.roomGrid.GetLength(0) / 2) + .5f + demoLevel.start.head.roomPos.x, (demoLevel.start.head.roomGrid.GetLength(1) / 2) + .5f + demoLevel.start.head.roomPos.y);
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
