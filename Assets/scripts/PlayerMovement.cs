using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speedPerS;
    public float sideSpeedPerS;
    public float speedIncresePerS;
    public GameInfo GI;
    public bool debug;

    float time;
    float currentSideSpeed;
    float currentSetSpeed;
    float maxSpeed;
    
    void Update()
    {
        time = Time.deltaTime;
        GI.currentSpeed = GI.player.GetComponent<Rigidbody>().velocity.z;
        // side to side motion
        if (Input.GetKey(KeyCode.A))
        {
            currentSideSpeed = -sideSpeedPerS * time;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentSideSpeed = sideSpeedPerS * time;
        }
        else 
        {
            currentSideSpeed = 0;
        }
        GI.player.GetComponent<Rigidbody>().AddForce(new Vector3(currentSideSpeed, 0, 0), ForceMode.VelocityChange);
        // going forward
        if ((currentSetSpeed < speedPerS))
        {
            currentSetSpeed += speedIncresePerS * time;
            GI.player.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, (currentSetSpeed - GI.currentSpeed) * (time * 325)), ForceMode.Force);
        }
        else 
        {
            currentSetSpeed = GI.currentSpeed;
        }
        if (debug)
        {
            if (GI.currentSpeed > maxSpeed) { maxSpeed = GI.currentSpeed; }
            Debug.Log("set speed: " + currentSetSpeed);
            Debug.Log("current speed: " + GI.currentSpeed);
            Debug.Log("max speed: " + maxSpeed);
        }
    }
}
