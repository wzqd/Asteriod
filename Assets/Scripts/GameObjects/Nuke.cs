using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Nuke : MonoBehaviour
{
    private void Awake()
    {
        EventMgr.Instance.AddEventListener("RestartGame", HideNuke);
    }

    private void OnEnable()
    {
        RandomSpawn();
    }

    private void HideNuke()
    {
        if(this == null) return;
        PoolMgr.Instance.PushObj("GameObjects/Nuke", this.gameObject); //push it back to the pool
    }

    
    public void RandomSpawn()
    {
        this.transform.position = new Vector3(Random.Range(ScreenBound.Instance.LeftEdge+10, ScreenBound.Instance.RightEdge-10),
            Random.Range(ScreenBound.Instance.UpEdge-10, ScreenBound.Instance.BotEdge+10), 0); //spawn with offsets
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "SpaceShip")
        {
            EventMgr.Instance.EventTrigger("TriggerNuke");
            AudioMgr.Instance.PlayAudio("ShipExplosion", false);

            HideNuke();
        }
    }
}
