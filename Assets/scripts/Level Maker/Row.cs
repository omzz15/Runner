using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private Vector3 myLocation;
    private RowBlock[] rowBlocks = new RowBlock[6];

    public Row()
    {
        for (int i = 0; i < 6; i++)
            rowBlocks[i] = new RowBlock();
    }

    public void setMyLocation(Vector3 location)
    {
        this.myLocation = location;
        for (int i=0; i<6; i++)
        {
            rowBlocks[i].setMyLocation(new Vector3(location.x+(4*i), location.y, location.z));
        }
    }

    public void drawBlocks(GameObject obj, Transform obsPos)
    {
        for (int i=0; i<6; i++)
        {
            rowBlocks[i].drawBlocks(obj , obsPos);
        }
    }

    public void setBlockCount(int bCount)
    {
        for (int i = 0; i < 6; i++)
            rowBlocks[i].setBlockCount(0);

        int remBCount = bCount % 6;
        while (remBCount > 0)
        {
            int rowIdx = Random.Range(0, 6);
            if (rowBlocks[rowIdx].getBlockCount() == 0)
            {
                rowBlocks[rowIdx].addBlockCount(1);
                remBCount -= 1;
            }
        }
        int eqBCount = bCount / 6;
        for (int i=0; i<6; i++)
        {
            this.rowBlocks[i].addBlockCount(eqBCount);
        }
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
