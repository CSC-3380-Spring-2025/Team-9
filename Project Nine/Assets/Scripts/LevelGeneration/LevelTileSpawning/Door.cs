using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    public string bossSceneName = "BossRoom";
    public float x = 3.4f;
    public float y = -9.15f; // Adjust these values as needed


    public void Interact()
    {
        StartCoroutine(LoadBossScene());
    }

    System.Collections.IEnumerator LoadBossScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(bossSceneName);
        while (!async.isDone)
            yield return null;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player)
        {
            Vector3 spawnPosition = new Vector3(x, y, 0f); 
            Debug.Log("Teleporting player to spawn point at: " + spawnPosition);
            player.transform.position = spawnPosition; 
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }
}