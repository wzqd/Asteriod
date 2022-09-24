using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [Header("Movement")]
    [SerializeField] private float thrustSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Vector3 direction;
    

    [Header("Shooting")] 
    [SerializeField] private int bulletSpeed;
    [SerializeField] private int shootInterval;

    [Header("Other")] 
    [SerializeField] private int health;
    [SerializeField] private int invincibleTime;
    
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        OutOfScreenDetection();
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
}
