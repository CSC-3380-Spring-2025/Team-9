using Unity.VisualScripting;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    [SerializeField] private SettingsMenuSpawner settingsMenuSpawner;

    private bool isPaused;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
        settingsMenuSpawner.OpenSettings();
        isPaused = true;


    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        settingsMenuSpawner.CloseSettings();
        isPaused = false;
    }
}
