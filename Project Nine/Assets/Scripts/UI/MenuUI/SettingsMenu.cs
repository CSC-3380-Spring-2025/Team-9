
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        // volume
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 1.0f);
        AudioListener.volume = savedVolume;
        volumeSlider.value = savedVolume;
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // fullscreen
        bool savedFullscreen = PlayerPrefs.GetInt("IsFullscreen", 0) == 1;
        Screen.fullScreen = savedFullscreen;
        fullscreenToggle.isOn = savedFullscreen;
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);

        // resolutions
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentResIndex = 0;
        var options = new System.Collections.Generic.List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);

        int savedResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", currentResIndex);
        if (savedResolutionIndex >= 0 && savedResolutionIndex < resolutions.Length)
        {
            currentResIndex = savedResolutionIndex;
        }


        resolutionDropdown.value = savedResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        Screen.SetResolution(resolutions[savedResolutionIndex].width, resolutions[savedResolutionIndex].height, Screen.fullScreen);

        resolutionDropdown.onValueChanged.AddListener(SetResolution);

    }

    // function to set the volume
    public static void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("GameVolume", volume);
        PlayerPrefs.Save();
    }
    
    // function to set fullscreen on and off
    public static void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("IsFullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }


    // function to set the resolution
    public void SetResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);

        PlayerPrefs.SetInt("ResolutionIndex", index);
        PlayerPrefs.Save();
    }

    // destroys menu object
    public void CloseMenu()
    {
        FindFirstObjectByType<PauseManager>().ResumeGame();
        Destroy(gameObject);
    }
}
