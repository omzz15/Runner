using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSection : MonoBehaviour
{
    private Vector3 myLocation;
    private int level;
    private Row row1;
    private Row row2;

    public ObstacleSection()
    {
        row1 = new Row();
        row2 = new Row();
    }

    public void setMyLocation(Vector3 location)
    {
        this.myLocation = new Vector3(location.x, location.y, location.z);
        this.row1.setMyLocation(this.myLocation);
        this.row2.setMyLocation(new Vector3(location.x, location.y, location.z + 3));
    }

    public void setLevel(int level)
    {
        this.level = level;
        if (this.level % 2 == 0)
        {
            row1.setBlockCount(this.level / 2);
            row2.setBlockCount(this.level / 2);
        } else
        {
            row1.setBlockCount(this.level / 2);
            row2.setBlockCount(1 + (this.level / 2));
        }
    }

    public void drawBlocks(GameObject obj, Transform obsPos)
    {
        this.row1.drawBlocks(obj, obsPos);
        this.row2.drawBlocks(obj, obsPos);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
