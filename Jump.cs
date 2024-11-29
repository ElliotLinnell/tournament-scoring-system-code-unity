using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using Random = System.Random;
public class jump:MonoBehaviour
{
    public Button jumpButton;
    public Canvas settignsCanvas;
    public Canvas mainCanvas;
    public Canvas secondCanvas;
    public Canvas thirdCanvas;
    public Canvas fourthCanvas;
    public Canvas fifthCanvas;
    public Canvas sixthCanvas;
    public Canvas seventhCanvas;
    public Canvas eighthCanvas;
    public AudioSource audioSource;

    public void handleJump()
    {
        Debug.Log("Jumping");
        if (settignsCanvas.enabled)
        {
            settignsCanvas.enabled = false;
            Random rnd = new Random();
            int random = rnd.Next(1, 11);
            if (random == 1)
            {
                mainCanvas.enabled = true;
                secondCanvas.enabled = false;
                thirdCanvas.enabled = false;
                fourthCanvas.enabled = false;
            }
            else if (random == 2)
            {
                secondCanvas.enabled = true;
                mainCanvas.enabled = false;
                thirdCanvas.enabled = false;
                fourthCanvas.enabled = false;
            }
            else if (random == 3)
            {
                thirdCanvas.enabled = true;
                mainCanvas.enabled = false;
                secondCanvas.enabled = false;
                fourthCanvas.enabled = false;
            }
            else if (random == 4)
            {
                fourthCanvas.enabled = true;
                mainCanvas.enabled = false;
                secondCanvas.enabled = false;
                thirdCanvas.enabled = false;
            }
            else if (random == 5)
            {
                fifthCanvas.enabled = true;
                mainCanvas.enabled = false;
                secondCanvas.enabled = false;
                thirdCanvas.enabled = false;
                fourthCanvas.enabled = false;
            }
            else if (random == 6)
            {
                sixthCanvas.enabled = true;
                mainCanvas.enabled = false;
                secondCanvas.enabled = false;
                thirdCanvas.enabled = false;
                fourthCanvas.enabled = false;
            }
            else if (random == 7)
            {
                seventhCanvas.enabled = true;
                mainCanvas.enabled = false;
                secondCanvas.enabled = false;
                thirdCanvas.enabled = false;
                fourthCanvas.enabled = false;
            }
            else if (random == 8)
            {
                eighthCanvas.enabled = true;
                mainCanvas.enabled = false;
                secondCanvas.enabled = false;
                thirdCanvas.enabled = false;
                fourthCanvas.enabled = false;
            }
            else
            {
                mainCanvas.enabled = true;
                secondCanvas.enabled = false;
                thirdCanvas.enabled = false;
                fourthCanvas.enabled = false;
            }

            audioSource.Play();
            StartCoroutine(WaitAndSwitchCanvas());


        }
    }
    public IEnumerator WaitAndSwitchCanvas()
    {
        yield return new WaitForSeconds(3);
        mainCanvas.enabled = false;
        settignsCanvas.enabled = true;
    }
}