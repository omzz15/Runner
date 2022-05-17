using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerCollision : MonoBehaviour
{
    public float minSpeed;
    public float minSafeYAmount;
    public GameInfo GI;
 
    // Update is called once per frame
    void Update()
    {
        if (GI.safePeriodOver)
        {
            if (GI.player.GetComponent<Transform>().position.y < minSafeYAmount)
            {
                GI.TakingDamage = true;
                GI.amountOfDamage = GI.DamageForYToLow * Time.deltaTime;
            }
            else if (GI.player.GetComponent<Rigidbody>().velocity.z < minSpeed)
            {
                GI.TakingDamage = true;
                GI.amountOfDamage = GI.DamageForSpeed * Time.deltaTime;
            }
            else { GI.TakingDamage = false; }
        }
    }
}
