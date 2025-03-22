using UnityEngine;

public class NextScene : MonoBehaviour
{
    [SerializeField] private Scene nextScene;
    [SerializeField] private SceneController controller;
        
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.ChangeScene(nextScene);
        }
    }
}
