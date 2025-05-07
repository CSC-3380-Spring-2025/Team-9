using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBossRoom : MonoBehaviour
{
    public string bossSceneName = "BossRoom1";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        StartCoroutine(LoadBossScene());
        
    }


    System.Collections.IEnumerator LoadBossScene()
    {

        AsyncOperation async = SceneManager.LoadSceneAsync(bossSceneName);
        while (!async.isDone)
            yield return null;

        GameObject spawn = GameObject.Find("SpawnPoint");
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (spawn && player)
        {
            Debug.Log("Teleporting player to spawn point at: " + spawn.transform.position);
            player.transform.position = spawn.transform.position;
        }
        else
        {
            if (!spawn) Debug.LogError("Spawn point not found!");
            if (!player) Debug.LogError("Player not found!");
        }
    }


}
