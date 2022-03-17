using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI scoreText;
    public int score = 0;

    private void Start()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

        scoreText.text = "Pisteet: " + score.ToString();
    }
    private void Update()
    {
        if (scoreText == null)
        {
            return;
        }

        scoreText.text = "Pisteet: " + score.ToString();
    }
    public void addScore(int newScore)
    {
        score += newScore;
    }
}
