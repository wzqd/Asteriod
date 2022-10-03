using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Nuke : MonoBehaviour
{
    private void OnEnable()
    {
        RandomSpawn();
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
            
            PoolMgr.Instance.PushObj("GameObjects/Nuke", this.gameObject);
        }
    }
}
