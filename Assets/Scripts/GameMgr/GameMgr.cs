using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    private void Start()
    {
        UIControl.GetInstance();
        AsteroidSpawner.GetInstance();
    }
}
