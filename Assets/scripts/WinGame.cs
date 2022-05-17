using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public float winDelay = 0;
    public GameInfo GI;

    float winTime;

    private void OnCollisionEnter(Collision collision)
    {
        GI.gameWon = true;
        winTime = Time.time;
    }

    private void Update()
    {
        if(GI.gameWon && Time.time - winTime >= winDelay)
            SceneManager.LoadScene(sceneName: "Win Screen");
    }
}
