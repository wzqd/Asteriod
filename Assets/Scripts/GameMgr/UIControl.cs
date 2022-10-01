using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : SingletonMono<UIControl>
{

    void Start()
    {
        UIMgr.Instance.ShowPanel<StartPanel>("StartPanel",E_PanelLayer.Top);
        
        EventMgr.Instance.AddEventListener("StartGame", HideStartPanel);
        EventMgr.Instance.AddEventListener("StartGame", ShowScoreBoard);
        EventMgr.Instance.AddEventListener("StartGame", ShowHealthBar);
        
        EventMgr.Instance.AddEventListener("ReturnToMenu", HideScoreBoard);
        EventMgr.Instance.AddEventListener("ReturnToMenu", HideHealthBar);
        EventMgr.Instance.AddEventListener("ReturnToMenu", ShowStartPanel);
        
        
        EventMgr.Instance.AddEventListener("GameOver", ShowEndGamePanel);
        EventMgr.Instance.AddEventListener("RestartGame", HideEndGamePanel);

    }
    
    void Update()
    {
        
    }
    private void ShowStartPanel()
    {
        UIMgr.Instance.ShowPanel<StartPanel>("StartPanel",E_PanelLayer.Top);
    }
    private void HideStartPanel()
    {
        UIMgr.Instance.HidePanel("StartPanel");
    }

    private void ShowEndGamePanel()
    {
        UIMgr.Instance.ShowPanel<EndGame>("EndGame",E_PanelLayer.Top);
    }
    private void HideEndGamePanel()
    {
        UIMgr.Instance.HidePanel("EndGame");
    }
    
    private void ShowScoreBoard()
    {
        UIMgr.Instance.ShowPanel<ScoreBoard>("ScoreBoard",E_PanelLayer.Bot);
    }
    private void HideScoreBoard()
    {
        UIMgr.Instance.HidePanel("ScoreBoard");
    }
    
    private void ShowHealthBar()
    {
        UIMgr.Instance.ShowPanel<HealthBar>("HealthBar",E_PanelLayer.Bot);
    }

    private void HideHealthBar()
    {
        UIMgr.Instance.HidePanel("HealthBar");
    }
    
}
