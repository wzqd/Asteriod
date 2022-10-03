using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        EventMgr.Instance.AddEventListener("RestartGame", HideExplosion);
    }

    void OnEnable()
    {
        Invoke("HideExplosion", 0.7f); //0.7s is the length of explosion animation
    }

    private void HideExplosion()
    {
        PoolMgr.Instance.PushObj("GameObjects/Explosion", this.gameObject);
    }
    
}
