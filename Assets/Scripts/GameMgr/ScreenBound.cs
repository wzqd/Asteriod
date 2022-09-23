using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBound : Singleton<ScreenBound>
{
    private float leftEdge;
    private float rightEdge;
    private float upEdge;
    private float botEdge;
    
    void Awake()
    {
        Vector2 cornerPos = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        leftEdge = -cornerPos.x;
        rightEdge = cornerPos.x;
        upEdge = cornerPos.y;
        botEdge = -cornerPos.y;
    }

    public float getLeftEdge()
    {
        return leftEdge;
    }    
    
    public float getRightEdge()
    {
        return rightEdge;
    }    
    
    public float getUpEdge()
    {
        return upEdge;
    }    
    
    public float getBotEdge()
    {
        return botEdge;
    }
}
