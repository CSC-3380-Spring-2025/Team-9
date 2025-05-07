using UnityEngine;

public class SettingsMenuSpawner : MonoBehaviour
{
    public GameObject settingsMenuPrefab;

    [HideInInspector] public GameObject currentMenu;

    public void OpenSettings()
    {
        if (currentMenu == null)
        {
            currentMenu = Instantiate(settingsMenuPrefab, GameObject.Find("Canvas").transform);
        }
    }

    public void CloseSettings()
    {
        if (currentMenu != null)
        {
            Destroy(currentMenu);
            currentMenu = null;
        }
    }
}
