using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : BasePanel
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected override void OnClick(string buttonName)
    {
        switch (buttonName)
        {
            case "StartButton":
                SceneMgr.Instance.LoadScene("GameScene", (() =>
                {
                    print("enter game scene");
                    PoolMgr.Instance.Clear();
                    EventMgr.Instance.EventTrigger("StartGame"); //trigger event, let UIControl do the things
                    AudioMgr.Instance.ClearAudio();

                }));
                break;
            case "QuitButton":
                Application.Quit();
                break;
        }
    }
}
