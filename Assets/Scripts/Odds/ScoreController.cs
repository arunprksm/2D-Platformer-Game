using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    int score = 0;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUI();
    }

    public void IncrementScore(int increment)
    {
        score += increment;
        RefreshUI();
    }

    void RefreshUI()
    {
        scoreText.text = "Score: " + score;
        //
        //scoreText.SetText
    }
}
