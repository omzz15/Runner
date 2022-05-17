using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaker1 : MonoBehaviour
{

    public Transform player;
    public Vector3 myLocation;
    public GameObject obs;
    public Transform obsPos;
    public int with;
    public int lenth;
    public int level;
    private ObstacleSection oSection = new ObstacleSection();

    public void setLevel(int level) 
    {
        oSection.setLevel(level);
    }
    public void makeobs(Vector3 pos, GameObject obs, Transform obsPos) 
    {
        oSection.setMyLocation(pos);
        oSection.drawBlocks(obs, obsPos);
    }
    void Start()
    {
        oSection.setLevel(level);
    }

    // Update is called once per frame
    void Update()
    {
        while (myLocation.z < lenth)
        {
            myLocation.z += 6;
            oSection.setMyLocation(myLocation);
            oSection.drawBlocks(obs, obsPos);
        }
    }

}
