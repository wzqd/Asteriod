using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private float maxSpeed;

    public SpaceShip ship;

    [SerializeField] private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ship = GameObject.FindObjectOfType<SpaceShip>();
        
        Spawn();

        
    }
    
    void Update()
    {

    }
    
    
    private void Spawn()
    {
        float scale = Random.Range(0.2f, 1);
        transform.localScale = new Vector2(scale, scale); //Spawn with random size
        
        transform.rotation = Quaternion.Euler(0,0,Random.Range(0, 360)); //Spawn with random size
        
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
}
