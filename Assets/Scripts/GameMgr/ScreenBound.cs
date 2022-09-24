using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ScreenBound : Singleton<ScreenBound>
{

    public float LeftEdge { get; }
    public float RightEdge{ get; }
    public float UpEdge{ get; }
    public float BotEdge{ get; }
    


    public ScreenBound()
    {
        Vector2 cornerPos = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        LeftEdge = -cornerPos.x;
        RightEdge = cornerPos.x;
        UpEdge = cornerPos.y;
        BotEdge = -cornerPos.y;
    }

    public bool IsOutOfBound(Vector2 position)
    {
        if (position.x > RightEdge || position.x < LeftEdge) return true;
        if (position.y > UpEdge || position.y < BotEdge) return true;
        return false;
    }
    
}
