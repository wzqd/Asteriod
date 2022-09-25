using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : BasePanel
{
    [SerializeField] private int health = 3;
    private List<Image> healthImages = new List<Image>();
    void Start()
    {
        for (int i = 1; i <= health; i++)
        {
            healthImages.Add(GetUIComponent<Image>("Health" + i)); //get all children images 

        }

        EventMgr.Instance.AddEventListener("AsteroidHitSpaceShip", ReduceShipHealth);
    }
    
    void Update()
    {
        
    }

    private void ReduceShipHealth()
    {
        health--; //reduce health
        if (health >= 0) //if it still has health
        {
            healthImages[health].gameObject.SetActive(false); //reduce health in ui
        }

        
    }
}
