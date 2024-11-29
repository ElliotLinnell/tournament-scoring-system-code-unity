using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    } //loads main scene
    public void QuitGame()
    {
        Application.Quit();
    } //quits game
    public void openMenu()
    {
        SceneManager.LoadScene("Menu");
    } //loads menu scene
    public void gamba()
    {
        SceneManager.LoadScene("Gamba");
    } //loads gamba scene
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed");
            openMenu();
        }
    } //opens menu scene when escape key is pressed
}
