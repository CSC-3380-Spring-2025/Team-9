using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private GameObject player;

    // game objects to destroy when the player dies. Provide them in the editor, so you don't need to initialie the array with a size
    // this script needs the persist across scenes scripts otherwise the array will be emptied when the boss room is loaded.
    public GameObject[] gameObjects; 
    private void Start()
    {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
        // Automatically find the player and assign the PlayerHealth component
        // if (playerHealth == null)
        // {
        //     player = GameObject.FindGameObjectWithTag("Player");
        //     if (player != null)
        //     {
        //         playerHealth = player.GetComponent<PlayerHealth>();
        //     }
        //     else
        //     {
        //         Debug.LogError("Player GameObject with tag 'Player' not found!");
        //     }
        // }

        playerHealth.OnPlayerDeath += Testing_OnPlayerDeath;
    }

    private void Update()
    {
        // if (playerHealth != null && playerHealth.currentHealthPoints <= 0)
        // {
        //     SceneManager.LoadScene("ResetMenuScene");
        // }
    }

    public void Testing_OnPlayerDeath(object sender, EventArgs  e)
    {
        Debug.Log("Event was listened to susccesfully. the player died");
        if (gameObjects == null)
        {
            Debug.Log("Array of objects to destroy on player death has not been initialized");
        }
        else {

            foreach (GameObject obj in gameObjects)
            {
                if (obj != null) Destroy(obj);
            }

        }

        // destroy thie game over manager too
        Destroy(gameObject);
    }

    
}