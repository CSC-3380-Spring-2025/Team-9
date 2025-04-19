using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MovementTestScene"); // loads the scene named "MovementTestScene"
    }
}
