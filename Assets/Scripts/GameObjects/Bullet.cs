using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private BoxCollider2D col;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        if (ScreenBound.Instance.IsOutOfBound(this.transform.position)) //if bullet is out of screen bound
        {
            PoolMgr.Instance.PushObj("GameObjects/Bullet", this.gameObject); //push it into the pool
        }
    }
    
}
