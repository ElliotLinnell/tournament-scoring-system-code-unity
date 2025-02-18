using UnityEngine;
using System.Collections;

public class ScoreboardUI : MonoBehaviour
{
    public GameObject scoreboardPanel;

    /// <summary>
    /// Initializes the scoreboard panel by setting its local scale to zero,
    /// effectively hiding it at the start of the game.
    /// </summary>
    void Start()
    {
        scoreboardPanel.transform.localScale = Vector3.zero; 
    } // end of Start

    public void ShowScoreboard()
    {
        StartCoroutine(AnimatePanel(scoreboardPanel));
    } // end of ShowScoreboard

    private IEnumerator AnimatePanel(GameObject panel)
    {
        float duration = 0.5f;
        float elapsed = 0f;

        Vector3 startScale = Vector3.zero;
        Vector3 endScale = Vector3.one;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            panel.transform.localScale = Vector3.Lerp(startScale, endScale, elapsed / duration);
            yield return null;
        }

        panel.transform.localScale = endScale;
    } // end of AnimatePanel
}
