using UnityEngine;

public class SettingsMenuSpawner : MonoBehaviour
{
    public GameObject settingsMenuPrefab;

    private GameObject currentMenu;

    public void OpenSettings()
    {
        if (currentMenu == null)
        {
            currentMenu = Instantiate(settingsMenuPrefab, GameObject.Find("Canvas").transform);
        }
    }
}
