using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UIElements;
using System;

public class SnailSpawn : MonoBehaviour
{
    private GameObject snailPrefab;
    private Walker1x1ChunkLevel level;
    private Vector3 spawnPosition;

    public SnailSpawn(Walker1x1ChunkLevel dlevel, GameObject snail)
    {
        snailPrefab = snail;
        level = dlevel;
    }
    public void SetSpawnLocation()
    {
        spawnPosition = new Vector3(level.end.tail.roomPos.x + 16, level.end.tail.roomPos.y + 16);
        if (snailPrefab != null)
        {
            Instantiate(snailPrefab, spawnPosition, Quaternion.identity);
        }
        else 
        {
            Debug.Log("RAHHHHHHHHHH");
        }
    }
}
