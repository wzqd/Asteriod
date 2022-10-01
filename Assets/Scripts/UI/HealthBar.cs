using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : BasePanel
{
    [SerializeField] private int health;
    private List<Image> healthImages;
    void Start()
    {
        healthImages = new List<Image>();
        
        for (int i = 0; i <= health; i++)
        {
            healthImages.Add(GetUIComponent<Image>("Health" + i)); //get all children images 

        }

        EventMgr.Instance.AddEventListener("AsteroidHitSpaceShip", ReduceShipHealth);
        
        
        EventMgr.Instance.AddEventListener("RestartGame", ResetShipHealthUI);
        EventMgr.Instance.AddEventListener("ReturnToMenu", ResetShipHealthUI);
        EventMgr.Instance.AddEventListener("GameOver", ResetShipHealth);
        EventMgr.Instance.AddEventListener("ReturnToMenu", ResetShipHealth);

    }
    
    void Update()
    {
        
    }

    private void ReduceShipHealth()
    {
        if (health >= 0) //if it still has health
        {
            if (healthImages[health] == null) return;
            healthImages[health].gameObject.SetActive(false); //reduce health in ui
            health--; //reduce health
        }
        else if (health < 0)
        {
            EventMgr.Instance.EventTrigger("GameOver"); //game over
        }
    }

    private void ResetShipHealthUI() //reset the health ui of ship
    {
        for (int i = 0; i <= health; i++)
        {
            if (healthImages[health] == null) return;
            healthImages[i].gameObject.SetActive(true); //reset images on ui
        }
    }   
    private void ResetShipHealth() //reset the health of ship
    {
        health = 2;
    }
    
    public override void Show() //adjust size of the panel
    {
        (transform as RectTransform).sizeDelta = new Vector2(250, 100);
        (transform as RectTransform).anchoredPosition = new Vector2(190, -166);
    }
}
