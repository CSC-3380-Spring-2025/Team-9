using UnityEngine;

public class SnailSpawn : MonoBehaviour
{
    [SerializeField] private GameObject snailPrefab;
    private Vector3 spawnPosition;

    public void SetSpawnLocation(Walker1x1ChunkLevel level)
    {
        
        spawnPosition = new Vector3(level.end.tail.roomPos.x + 15.5f, level.end.tail.roomPos.y + 15.5f);

        if (snailPrefab != null)
        {
            Instantiate(snailPrefab, spawnPosition, Quaternion.identity);
        }
        else 
        {
            Debug.Log("snailPrefab does not exist");
        }
    }
    public void DestroySnail()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Snail");
        if(objects.Length > 0)
        {
            foreach (GameObject obj in objects)
            {
                DestroyImmediate(obj);
            }
        }
        else
        {
            Debug.Log("snailPrefab was not destroyed");
        }
    }
}
