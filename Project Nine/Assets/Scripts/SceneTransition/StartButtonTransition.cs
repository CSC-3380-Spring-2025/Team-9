using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonTransition : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MovementTestScene"); // loads the scene named "MovementTestScene"
    }
}
