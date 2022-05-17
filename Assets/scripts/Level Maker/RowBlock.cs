using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowBlock : MonoBehaviour
{
    private Vector3 myLocation;
    private int blockCount;

    public int getBlockCount()
    {
        return blockCount;
    }

    public void addBlockCount(int amt)
    {
        blockCount += amt;
    }

    public void setBlockCount(int cnt)
    {
        this.blockCount = cnt;
    }

    public void drawBlocks(GameObject obj, Transform obsPos)
    {
        bool[] drawFlags = { false, false, false, false };
        int remBCount = blockCount;
        while (remBCount > 0)
        {
            int Idx = Random.Range(0, 4);
            if (!drawFlags[Idx])
            {
                GameObject duplicate = Instantiate(obj,new Vector3(myLocation.x + Idx, myLocation.y, myLocation.z), obsPos.rotation);
                drawFlags[Idx] = true;
                remBCount -= 1;
            }
        }
        
    }

    public void setMyLocation(Vector3 location)
    {
        this.myLocation = location;
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
