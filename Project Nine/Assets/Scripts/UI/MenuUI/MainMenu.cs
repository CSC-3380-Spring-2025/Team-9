using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("LevelGenerationScene_v2"); // loads the scene named "MovementTestScene"
    }
}
