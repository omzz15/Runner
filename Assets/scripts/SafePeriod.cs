using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePeriod : MonoBehaviour
{

    public float safePeriod;
    public GameInfo GI;

    void Update()
    {
        safePeriod -= Time.deltaTime;
        if (safePeriod <= 0)
        {
            GI.safePeriodOver = true;
            safePeriod = 0;
        }
        else 
        {
            GI.safePeriodOver = false;
        }
    }
}
