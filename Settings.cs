/// <summary>
/// The Settings class manages the game settings such as resolution, fullscreen mode, and scene transitions.
/// </summary>
public class Settings : MonoBehaviour
{
    /// <summary>
    /// Dropdown for selecting screen resolution.
    /// </summary>
    public TMP_Dropdown resolutionDropdown;

    /// <summary>
    /// Toggle for enabling or disabling fullscreen mode.
    /// </summary>
    public Toggle fullscreenToggle;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// Checks if the Escape key is pressed to return to the menu scene.
    /// </summary>
    public void Start()
    {
        // Implementation here
    }

    /// <summary>
    /// Loads the main game scene.
    /// </summary>
    public void ReturnToGame()
    {
        // Implementation here
    }

    /// <summary>
    /// Sets the screen resolution based on the selected index.
    /// </summary>
    /// <param name="resolutionIndex">Index of the selected resolution.</param>
    public void setResolution(int resolutionIndex)
    {
        // Implementation here
    }

    /// <summary>
    /// Sets the fullscreen mode based on the provided boolean value.
    /// </summary>
    /// <param name="isFullscreen">True to enable fullscreen, false to disable.</param>
    public void setFullscreen(bool isFullscreen)
    {
        // Implementation here
    }

    /// <summary>
    /// Applies the selected resolution and fullscreen settings.
    /// </summary>
    public void applySettings()
    {
        // Implementation here
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void QuitGame()
    {
        // Implementation here
    }
}
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Settings: MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void ReturnToGame()
    {
        SceneManager.LoadScene("Main");
    }  
    public void setResolution(int resolutionIndex)
    {
        resolutionDropdown.value = resolutionIndex;
        Resolution resolution = Screen.resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void setFullscreen(bool isFullscreen)
    {
        fullscreenToggle.isOn = isFullscreen;
        Screen.fullScreen = isFullscreen;
    }
    public void applySettings()
    {
        setResolution(resolutionDropdown.value);
        setFullscreen(fullscreenToggle.isOn);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
