using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    private Rigidbody2D rb;
    private Renderer rd;
    private Collider2D col;
    
    [Header("Movement")]
    [SerializeField] private float thrustSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Vector3 direction;
    

    [Header("Shooting")] 
    [SerializeField] private int bulletSpeed;

    [Header("InvincibleTime")]
    [SerializeField] private int invincibleTime;
    [SerializeField] private float blinkInterval;
    private Coroutine blinkCoroutine;
    
    
    
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rd = GetComponent <Renderer>();
        col = GetComponent<Collider2D>();
        
        EventMgr.Instance.AddEventListener("RestartGame", ResetShipPosition);
        EventMgr.Instance.AddEventListener("AsteroidHitSpaceShip", ShipInvincible);
        

    }
    void Update()
    {
        Shoot();
        OutOfScreenDetection();

    }

    private void FixedUpdate() //physic related
    {
        Move();
    }


    private void Move()
    {
        direction = (transform.rotation * Vector3.up).normalized; //get direction vector from quaternion

        if (Input.GetKey(KeyCode.J)) //turn left
        {
            rb.AddTorque(rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.L)) //turn right
        {
            rb.AddTorque(-rotateSpeed);
        }
        
        if (Input.GetKey(KeyCode.K)) //thrust
        {
            rb.AddForce(direction * thrustSpeed);
        }
    }

    private void Shoot()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bulletObj = PoolMgr.Instance.GetObj("GameObjects/Bullet"); //get object from pool
            bulletObj.transform.position = this.transform.position + direction; //adjust its position to the head of the ship
            bulletObj.transform.rotation = this.transform.rotation; //adjust its rotation
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.rb.velocity = direction * this.bulletSpeed; //adjust its speed
            
            //add audio
            AudioMgr.Instance.PlayAudio("Laser", false);
        }
    }

    private void ShipInvincible()
    {
        if (col == null) return;
        col.enabled = false; //turn off collider, and become invincible
        TimeMgr.Instance.StartFuncTimer(invincibleTime, () =>
            {
                blinkCoroutine = StartCoroutine("ShipBlinkCoroutine"); //blink while being invincible
            },
            (() =>
            {
                if (this == null) return;
                StopCoroutine(blinkCoroutine);
                rd.enabled = true; //always show renderer after blinking
                col.enabled = true;
            }));

    }

    private IEnumerator ShipBlinkCoroutine()
    {
        while (true)
        {
            if (rd == null) yield break;
            rd.enabled = !rd.enabled; //blink
            yield return new WaitForSeconds(blinkInterval);
        }
    }
    
    private void OutOfScreenDetection()
    {
        if (transform.position.x > ScreenBound.Instance.RightEdge) //beyond right edge
        {
            transform.position = new Vector2(ScreenBound.Instance.LeftEdge, transform.position.y);
        }

        if (transform.position.x < ScreenBound.Instance.LeftEdge) //beyond left edge
        {
            transform.position = new Vector2(ScreenBound.Instance.RightEdge, transform.position.y);
        }

        if (transform.position.y > ScreenBound.Instance.UpEdge) //beyond up edge
        {
            transform.position = new Vector2(transform.position.x, ScreenBound.Instance.BotEdge);
        }

        if (transform.position.y < ScreenBound.Instance.BotEdge) //beyond bottom edge
        {
            transform.position = new Vector2(transform.position.x, ScreenBound.Instance.UpEdge);
        }
    }

    private void ResetShipPosition()
    {
        if(this == null) return;
        this.transform.position = new Vector3(0, 0, 0);
        this.transform.eulerAngles = new Vector3(0, 0, 0);
        rb.Sleep(); //to instantly stop objects with add force
    }
}
