using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void Start()
    {
        // Automatically find the player and assign the PlayerHealth component
        if (playerHealth == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerHealth = player.GetComponent<PlayerHealth>();
            }
            else
            {
                Debug.LogError("Player GameObject with tag 'Player' not found!");
            }
        }
    }

    private void Update()
    {
        if (playerHealth != null && playerHealth.currentHealthPoints <= 0)
        {
            SceneManager.LoadScene("ResetMenuScene");
        }
    }
}