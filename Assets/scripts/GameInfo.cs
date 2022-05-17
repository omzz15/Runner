using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    // statistics
    public static string currentLevelStr;
    public static int currentLevel;
    public int currentScore = 0;
    public bool gameOver = false;
    public bool gameWon = false;

    // player info
    public GameObject player;
    public float currentSpeed;
    public float playerHealth;

    // health
    public bool safePeriodOver;
    public bool TakingDamage;
    public float amountOfDamage;
    // health - damage
    public float DamageForSpeed;
    public float DamageForYToLow;

}
