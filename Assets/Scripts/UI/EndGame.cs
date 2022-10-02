using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
                EventMgr.Instance.EventTrigger("RestartGame");
                Time.timeScale = 1; //restore the time
                break;
            
            case "ReturnButton":
                Time.timeScale = 1; //restore the time
                SceneMgr.Instance.LoadScene("StartMenu",(() =>
                {
                    EventMgr.Instance.EventTrigger("ReturnToMenu");
                    
                    PoolMgr.Instance.Clear();
                    UIMgr.Instance.HidePanel("EndGame");
                    
                    AudioMgr.Instance.ClearAudio();
                    print("return to start menu");
                }));
                break;
        }
    }
}
