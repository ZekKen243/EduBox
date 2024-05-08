using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{ 
    public int score;
    public TMP_Text scoreText;

    private void Start()
    {
        int initialScore;
        if (int.TryParse(scoreText.text, out initialScore))
        {
            score = initialScore;
        }
        else
        {
            Debug.LogError("Failed to parse text value as integer.");
        }
    }

    public void addScore()
    {
        score++;
        string scoreString = score.ToString();
        scoreText.text = scoreString;
    }
}
