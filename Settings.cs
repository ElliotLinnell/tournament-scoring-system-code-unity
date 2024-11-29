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
