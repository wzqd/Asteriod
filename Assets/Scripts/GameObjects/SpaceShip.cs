using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [Header("Movement")]
    [SerializeField] private int thrustSpeed;
    [SerializeField] private int rotateSpeed;
    [SerializeField] private Vector3 direction;
    

    [Header("Shooting")] 
    [SerializeField] private int bulletSpeed;
    [SerializeField] private int shootInterval;

    [Header("Other")] 
    [SerializeField] private int health;
    [SerializeField] private int invincibleTime;
    
    
    
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) //turn left
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.L)) //turn right
        {
            
        }

        if (Input.GetKeyDown(KeyCode.K)) //thrust
        {
            
        }
        
    }
}
