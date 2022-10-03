using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    
    [Header("Spawn")]
    [SerializeField] private float maxSpeed;

    private Vector3 smallSpawnLocation; //Spawn location

    public bool canBeSplit; //big asteroid can be split into smaller ones
    

    [SerializeField] private Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        EventMgr.Instance.AddEventListener("RestartGame", HideAsteroid);
        EventMgr.Instance.AddEventListener("TriggerNuke", HideAsteroid);
        
        
    }

    private void OnEnable()
    {
        RandomSpawn(); //spawn when out of the pool
    }

    void Update()
    {
        OutOfScreenDetection();
    }

    private void OutOfScreenDetection()
    {
        if (ScreenBound.Instance.IsOutOfBound(this.transform.position)) //if it is out of bound
        {
            HideAsteroid(); //push it back to the pool
        }
    }

    private void HideAsteroid()
    {
        canBeSplit = false; //clear the flag;
        if(this == null) return;
        PoolMgr.Instance.PushObj("GameObjects/Asteroid", this.gameObject); //push it back to the pool
    }
    
    
    
    public void RandomSpawn()
    {
        float scale = Random.Range(0.2f, 1);
        transform.localScale = new Vector2(scale, scale); //Spawn with random size

        if (transform.localScale.x > 0.7f && transform.localScale.y > 0.7f )
        {
            canBeSplit = true;
        }
        
        transform.rotation = Quaternion.Euler(0,0,Random.Range(0, 360)); //Spawn with random angle
        
        int edge = Random.Range(0, 4);
        switch (edge) //Spawn at random edge
        {
            case 0: //left edge
                transform.position = new Vector2(ScreenBound.Instance.LeftEdge,
                    Random.Range(ScreenBound.Instance.UpEdge, ScreenBound.Instance.BotEdge));
                break;
            case 1: //right edge
                transform.position = new Vector2(ScreenBound.Instance.RightEdge,
                    Random.Range(ScreenBound.Instance.UpEdge, ScreenBound.Instance.BotEdge));
                break;
            case 2: //Top edge
                transform.position = new Vector2(Random.Range(ScreenBound.Instance.LeftEdge, ScreenBound.Instance.RightEdge),
                    ScreenBound.Instance.UpEdge);
                break;
            case 3: //Bottom edge
                transform.position = new Vector2(Random.Range(ScreenBound.Instance.LeftEdge, ScreenBound.Instance.RightEdge),
                    ScreenBound.Instance.BotEdge);
                break;
        }
        Vector3 direction = new Vector3(0,0,0) - this.transform.position;
        Vector3 randomDirection = Quaternion.Euler(new Vector3(0, 0, Random.Range(-30f, 30f))) * direction; //Random direction (within certain angles around center)
        rb.velocity = randomDirection * Random.Range(0.2f, maxSpeed);  //Random speed
        
    }

    private void smallAsteroidSpawn(Vector3 spawnPosition)
    {
        transform.position = spawnPosition; //set the initial position of small asteroid the same as the original one
        
        float scale = Random.Range(0.2f, 0.3f);
        canBeSplit = false; //small asteroid cannot be split any more
        transform.localScale = new Vector2(scale, scale); //Spawn with random size (within minimum and max split size)
        
        transform.rotation = Quaternion.Euler(0,0,Random.Range(0, 360)); //Spawn with random angle
        
        Vector3 randomDirection = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360f))) * Vector3.up; //Random direction (within certain angles around center)
        
        rb.velocity = randomDirection * Random.Range(0.2f, maxSpeed) * 10;  //Random speed (10 is offset)
        
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SpaceShip")) //if it hits space ship
        {
            EventMgr.Instance.EventTrigger("AsteroidHitSpaceShip");
            HideAsteroid();
            
            GameObject explosion = PoolMgr.Instance.GetObj("GameObjects/Explosion"); //create explosion
            explosion.transform.position = this.transform.position;
            explosion.transform.localScale = this.transform.localScale;
            
            AudioMgr.Instance.PlayAudio("ShipExplosion", false);
        }
        
        
        else if (other.gameObject.CompareTag("Bullet")) //if it hits a bullet
        {
            EventMgr.Instance.EventTrigger("AsteroidDestroyed"); //trigger event
            PoolMgr.Instance.PushObj("GameObjects/Bullet", other.gameObject); //push the bullet into pool
            

            if (canBeSplit) //if the asteroid is big enough to be destroyed
            {
                Asteroid smallAsteroid1 = PoolMgr.Instance.GetObj("GameObjects/Asteroid").GetComponent<Asteroid>(); //generate new asteroid
                smallAsteroid1.smallAsteroidSpawn(this.transform.position);
                
                //generate second asteroid
                Asteroid smallAsteroid2 = PoolMgr.Instance.GetObj("GameObjects/Asteroid").GetComponent<Asteroid>();
                smallAsteroid2.smallAsteroidSpawn(this.transform.position);
            }

            GameObject explosion = PoolMgr.Instance.GetObj("GameObjects/Explosion"); //create explosion
            explosion.transform.position = this.transform.position;
            explosion.transform.localScale = this.transform.localScale;
            
            AudioMgr.Instance.PlayAudio("AsteroidExplosion", false);
            //(code after hiding is meaningless)
            HideAsteroid();


        }
    }
    
}
