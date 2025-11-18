using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float timeLeft = 70f; // 5 minutes = 300 seconds
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI resultText;

    public bool goalScored = false;
    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        if (!goalScored)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                timeLeft = 0;
                LoseGame();
            }
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        timerText.text = minutes.ToString("0") + ":" + seconds.ToString("00");
    }

    public void WinGame()
    {
        gameEnded = true;
        resultText.gameObject.SetActive(true);
        resultText.text = "YOU WIN!";
    }

    void LoseGame()
    {
        gameEnded = true;
        resultText.gameObject.SetActive(true);
        resultText.text = "YOU LOSE!";
    }
}