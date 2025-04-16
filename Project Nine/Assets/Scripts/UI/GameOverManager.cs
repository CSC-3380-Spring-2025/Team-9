using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void Update()
    {
        if (playerHealth.currentHealthPoints <= 0)
        {
            SceneManager.LoadScene("ResetMenuScene");
        }
    }
}
