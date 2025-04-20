using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("quitting application..."); // logs msg to console
        Application.Quit(); // quits the application
    }
}
