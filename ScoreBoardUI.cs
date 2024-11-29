using UnityEngine;
using System.Collections;

public class ScoreboardUI : MonoBehaviour
{
    public GameObject scoreboardPanel;

    void Start()
    {
        scoreboardPanel.transform.localScale = Vector3.zero; 
    }

    public void ShowScoreboard()
    {
        StartCoroutine(AnimatePanel(scoreboardPanel));
    }

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
    }
}
