using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    private void Start()
    {
        UIControl.GetInstance();
        AsteroidSpawner.GetInstance();
        AudioMgr.Instance.ChangeAudioVolume(0.2f);
        
        AudioMgr.Instance.PlayBGM("SpaceGameBGM");
        AudioMgr.Instance.ChangeBGMVolume(0.2f);
    }
}
