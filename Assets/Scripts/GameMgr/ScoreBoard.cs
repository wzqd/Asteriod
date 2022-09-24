using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : BasePanel
{
    private float score;
    private TextMeshProUGUI scoreText;
    
    private void Start()
    {
        scoreText =  GetUIComponent<TextMeshProUGUI>("Score");
        EventMgr.Instance.AddEventListener("AsteroidDestroyed", AsteroidDestroyed);
    }

    private void Update()
    {
        // score += 1;//survival points
        scoreText.text = score.ToString(); 
    }

    private void AsteroidDestroyed()
    {
        score += 100; //hit asteroid points
    }
}
