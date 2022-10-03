using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeEffect : MonoBehaviour
{
    private Renderer rd;
    private float blinkTime = 0.1f;
    void Start()
    {
        rd = GetComponent<Renderer>();
        rd.enabled = false;
        
        EventMgr.Instance.AddEventListener("TriggerNuke", TriggerNukeEffect);
    }

    private void TriggerNukeEffect()
    {
        TimeMgr.Instance.StartFuncTimer(blinkTime, (() =>
        {
            rd.enabled = true;
        }), () =>
        {
            rd.enabled = false;
        });
    }
}
