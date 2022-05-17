using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Vector3 offset;
    public GameInfo GI;

    // Update is called once per frame
    void Update()
    {
        if(GI.player.GetComponent<Transform>().position != null)
            transform.position = GI.player.GetComponent<Transform>().position + offset;
    }
}