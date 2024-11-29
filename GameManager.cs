using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void openMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void gamba()
    {
        SceneManager.LoadScene("Gamba");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed");
            openMenu();
        }
    }
}
