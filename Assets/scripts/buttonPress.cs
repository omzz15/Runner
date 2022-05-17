using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class buttonPress : MonoBehaviour
{

    public int maxLevels = 24;
    
    public void pressedUnlimited() 
    {
        GameInfo.currentLevelStr = "unlimitedMode";
        SceneManager.LoadScene(sceneName: "unlimitedMode");  
    }
    public void mainMenuPressed() 
    {
        SceneManager.LoadScene(sceneName: "mainUI");
    }
    public void playPressed() 
    {
        SceneManager.LoadScene(sceneName: "Level Selector");
    }
    public void levelPressed(int level) 
    {
        GameInfo.currentLevelStr = "Level " + level;
        GameInfo.currentLevel = level;
        SceneManager.LoadScene(sceneName: GameInfo.currentLevelStr);
    }
    public void tryAgainPressed() 
    {
        if(GameInfo.currentLevelStr == null) GameInfo.currentLevelStr = "Level 1";
        SceneManager.LoadScene(sceneName: GameInfo.currentLevelStr); 
    }
    public void nextLevelPressed() 
    {
        GameInfo.currentLevel++;
        GameInfo.currentLevelStr = "Level " + GameInfo.currentLevel;
        SceneManager.LoadScene(sceneName: GameInfo.currentLevelStr);
    }
}
