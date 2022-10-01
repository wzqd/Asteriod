using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoDrag<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T instance;
    public static T Instance => instance;

    protected void Awake()
    {
        instance = this as T;
    }
}
