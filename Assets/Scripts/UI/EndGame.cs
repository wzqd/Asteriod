using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : BasePanel
{
    private Button retryButton;
    void Start()
    {
        retryButton = GetUIComponent<Button>("RetryButton");
    }
    
    void Update()
    {
        
    }

    private void ShowEndGamePanel()
    {
        this.gameObject.SetActive(true);
    }

    public override void Show() //adjust size of the panel
    {
        (transform as RectTransform).sizeDelta = new Vector2(1600, 400);
        (transform as RectTransform).anchoredPosition = new Vector2(0, 0);

        Time.timeScale = 0; //stop the game
    }

    protected override void OnClick(string buttonName)
    {
        switch (buttonName)
        {
            case "RetryButton":
                Time.timeScale = 1; //restore the time
                EventMgr.Instance.EventTrigger("RestartGame");
                break;
        }
    }
}
