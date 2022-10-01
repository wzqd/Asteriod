using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : BasePanel
{
    private float score;
    private Text scoreText;
    
    private void Start()
    {
        scoreText =  GetUIComponent<Text>("Score");
        EventMgr.Instance.AddEventListener("AsteroidDestroyed", AsteroidDestroyed);
        EventMgr.Instance.AddEventListener("RestartGame", ResetScore);
    }

    private void Update()
    {
        // score += 1;//survival points
    }

    private void AsteroidDestroyed()
    {
        score += 100; //hit asteroid points
        if (scoreText == null) return;
        scoreText.text = score.ToString(); //update score on ui
    }

    private void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString(); //update score on ui
    }

    public override void Show() //adjust size of the panel
    {
        (transform as RectTransform).sizeDelta = new Vector2(250, 100);
        (transform as RectTransform).anchoredPosition = new Vector2(190, -90);
    }
}
