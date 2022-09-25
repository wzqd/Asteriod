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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Asteroid")) //if it hit a asteroid
        {
            EventMgr.Instance.EventTrigger("AsteroidDestroyed"); //trigger event
            PoolMgr.Instance.PushObj("GameObjects/Bullet", this.gameObject); //push it into pool
            PoolMgr.Instance.PushObj("GameObjects/Asteroid", other.gameObject); //push the hit asteroid into pool
        }
    }

    void Update()
    {
        if (ScreenBound.Instance.IsOutOfBound(this.transform.position)) //if bullet is out of screen bound
        {
            PoolMgr.Instance.PushObj("GameObjects/Bullet", this.gameObject); //push it into the pool
        }
    }
    
}
