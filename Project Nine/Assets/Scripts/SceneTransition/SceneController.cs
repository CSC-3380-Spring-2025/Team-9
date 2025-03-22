using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    Scene1,
    Scene2
}

[CreateAssetMenu(fileName = "SceneController", menuName = "Scriptable Objects/Managers/SceneController")]
public class SceneController : ScriptableObject
{
    public void ChangeScene(Scene newScene)
    {
        switch(newScene)
        {
            case Scene.Scene1:
                SceneManager.LoadSceneAsync("Scene1");
                break;
            case Scene.Scene2:
                SceneManager.LoadSceneAsync("Scene2");
                break;
        }
    }
}
