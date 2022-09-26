using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    void Start()
    {
        EventMgr.Instance.AddEventListener("GameOver", ShowEndGamePanel);
        EventMgr.Instance.AddEventListener("RestartGame", HideEndGamePanel);
        
        UIMgr.Instance.ShowPanel<ScoreBoard>("ScoreBoard",E_PanelLayer.Bot);
        UIMgr.Instance.ShowPanel<HealthBar>("HealthBar",E_PanelLayer.Bot);
        
    }
    
    void Update()
    {
        
    }

    private void ShowEndGamePanel()
    {
        UIMgr.Instance.ShowPanel<EndGame>("EndGame",E_PanelLayer.Top);
    }

    private void HideEndGamePanel()
    {
        UIMgr.Instance.HidePanel("EndGame");
    }
}
