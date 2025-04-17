using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ImmortalSpawn : MonoBehaviour
{
    [SerializeField] private GameObject immortalPrefab;
    [SerializeField] private int maxNumImmortals = 3;
    [SerializeField] private float spawnChance = .1f;
    
    private Vector3 immortalPos;


    public void SetSpawnLocations(Walker1x1ChunkLevel level)
    {

        for (int i = 0; i < level.chunkList.Count; i++)
        {
            for (int j = 0; j < level.chunkList[i].roomList.Count; j++)
            {
                GameObject[] immortals = GameObject.FindGameObjectsWithTag("Immortal");

                if(immortals.Length == maxNumImmortals)
                {
                    goto finish;
                }
                if (!level.chunkList[i].roomList[j].Equals(level.start.head))
                {
                    if (Random.value < spawnChance)
                    {
                        SpiralTraversal(level.chunkList[i].roomList[j]);
                    }
                }
            }
        }
        finish:;
    }
    private void SpiralTraversal(WalkerRoom1x1 room)
    {
        int width = room.roomGrid.GetLength(0);
        int height = room.roomGrid.GetLength(1);

        int cx = width / 2;
        int cy = height / 2;

        int x = cx;
        int y = cy;

        int steps = 1;
        int leg = 0;
        int stepCount = 0;

        int dx = 1;
        int dy = 0;

        int visited = 0;
        int total = width*height;

        int max = Mathf.Max(width, height) * Mathf.Max(width, height);

        while (visited < total)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                if (room.roomGrid[x, y] == AbstractRoom.Grid.FLOOR &&
                room.roomGrid[x + 1, y] == AbstractRoom.Grid.FLOOR &&
                room.roomGrid[x, y + 1] == AbstractRoom.Grid.FLOOR &&
                room.roomGrid[x + 1, y + 1] == AbstractRoom.Grid.FLOOR)
                {
                    Vector3 immortalPos = new Vector3(room.roomPos.x + x + .5f, room.roomPos.y + y + 1, 0);
                    Instantiate(immortalPrefab, immortalPos, Quaternion.identity);
                    return;
                }
            }

            x+= dx;
            y+= dy;
            stepCount++;

            if (stepCount == steps)
            {
                stepCount = 0;

                int temp = dx;
                dx = -dy;
                dy = temp;

                leg++;

                if (leg % 2 == 0)
                {
                    steps++;
                }
            }
        }
    }
    public void DestroyImmortals()
    {
        GameObject[] immortals = GameObject.FindGameObjectsWithTag("Immortal");
        if (immortals.Length > 0)
        {
            foreach (GameObject obj in immortals)
            {
                DestroyImmediate(obj);
            }
        }
        else
        {
            Debug.Log("immortalPrefabs were not destroyed");
        }
    }
}
