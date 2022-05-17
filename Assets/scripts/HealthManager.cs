using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float health;
    public float healthLossFormLowSpeed;
    public float healthLossFromLowHight;
    public GameInfo GI;
    public bool debug;

    private void Start()
    {
        GI.playerHealth = health;
        GI.DamageForYToLow = healthLossFromLowHight;
        GI.DamageForSpeed = healthLossFormLowSpeed;
    }
    void Update()
    {
        if (GI.safePeriodOver && GI.TakingDamage && !GI.gameWon) 
        {
            health -= GI.amountOfDamage;
            GI.playerHealth = health;
            if (debug) { Debug.Log("health: " + GI.playerHealth); }
        }
        if (health <= 0) 
        {
            health = 0;
            GI.playerHealth = 0;
            GI.gameOver = true;
        }
    }
}
