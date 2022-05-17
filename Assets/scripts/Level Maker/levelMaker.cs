using UnityEngine;

public class levelMaker : MonoBehaviour
{
    LevelMaker1 maker = new LevelMaker1();
    
    public Transform obstaclePos;
    public GameObject Obs;
    public Vector3 offset;
    public Vector3 cubeDimentions;
    public int with;
    public float lenthOfTerain;
    public float SpaceBetweenThings;
    public int maxVeriation;
    public int maxHoleSpacing;
    public float maxStaircaseSpaceX;
    public float minStaircaseSpeceX;
    public float maxStaircaseSpaceZ;
    public int hardnessIncresse;
    public int MaxHardness;

    float numOfCubeNeeded;
    float lengthMade;
    float footPrintZ;


    void drawCube(float x, float y, float z)
    {
        GameObject duplicate = Instantiate(Obs, new Vector3(x, y, z), obstaclePos.rotation);
    }

    public void wallWithHole(float startX, float y, float z, int spot, int numberOfSpots, bool GoingLeft)
    {
        numOfCubeNeeded = with / cubeDimentions.x;
        footPrintZ = cubeDimentions.z;
        for (int i = 0; i < numOfCubeNeeded; i++)
        {
            if (i >= spot - 1 && i < (spot + numberOfSpots - 1))
            {
            }
            else
            {
                GameObject duplicate = Instantiate(Obs, new Vector3(startX, y, z), obstaclePos.rotation);
            }
            if (GoingLeft)
            {
                startX -= cubeDimentions.x;
            }
            else
            {
                startX += cubeDimentions.x;
            }
        }
    }

    void stairCase(float startX, float Y, float startZ, float spaceBetweenBlocksX, float spaceBetweenBlocksZ, int numOfBlocks, bool GoingLeft)
    {
        if (numOfBlocks <= 0)
        {
            numOfCubeNeeded = with / (cubeDimentions.x + spaceBetweenBlocksX);
            numOfBlocks = (int)numOfCubeNeeded;
        }

        for (int i = 0; i < numOfBlocks; i++)
        {
            if (GoingLeft)
            {
                GameObject duplicate = Instantiate(Obs, new Vector3(startX, Y, startZ), obstaclePos.rotation);
                startX -= cubeDimentions.x + spaceBetweenBlocksX;
            }
            else
            {
                GameObject duplicate = Instantiate(Obs, new Vector3(startX, Y, startZ), obstaclePos.rotation);
                startX += cubeDimentions.x + spaceBetweenBlocksX;
            }

            startZ += cubeDimentions.z + spaceBetweenBlocksZ;
            footPrintZ += cubeDimentions.z + spaceBetweenBlocksZ;

        }
    }

    bool random()
    {

        if (Random.Range(0, 2) < .5) { return true; }
        else { return false; }

    }
    void levelMakerr(float lenth, float spaceBetweenThings)
    {
        lengthMade = offset.z;
        footPrintZ = spaceBetweenThings;
        float randNum;
        int randX = Random.Range(1, 15);
        bool goLeft;
        float Xstart = offset.x;
        float staircaseSpaceX;
        float staircaseSpaceZ;
        float math;
        int numOfBlocks;

        while (lengthMade < lenthOfTerain)
        {
            if (Random.Range(0, 10) < 5)
            {
                randNum = Random.Range(0, 10);
                randX += Random.Range(-maxVeriation, maxVeriation);

                if (randX < 1) { randX = 1; }
                if (randX > with - 1) { randX = with - 1; }

                if (randNum < 5)
                {
                    //wallWithHole(offset.x, offset.y, lengthMade + spaceBetweenThings, Random.Range(1, maxHoleSpacing), randX, false);
                    wallWithHole(offset.x, offset.y, lengthMade + spaceBetweenThings, randX, Random.Range(2, maxHoleSpacing), false);
                }
                else if (randNum <= 10)
                {
                    goLeft = random();
                    staircaseSpaceX = Random.Range(minStaircaseSpeceX, maxStaircaseSpaceX);
                    staircaseSpaceZ = Random.Range(0, maxStaircaseSpaceZ);
                    numOfBlocks = Random.Range(3, with);

                    footPrintZ = 0;
                    if (numOfBlocks * (staircaseSpaceX + cubeDimentions.x) > with - 1)
                    {
                        math = (with - 1) / (staircaseSpaceX + cubeDimentions.x);
                        numOfBlocks = (int)math;
                    }
                    if (goLeft)
                    {
                        Xstart = offset.x + (with - 1);
                        math = Xstart - (numOfBlocks * (staircaseSpaceX + cubeDimentions.x));
                    }
                    else
                    {
                        Xstart = offset.x;
                        math = Xstart + (numOfBlocks * (staircaseSpaceX + cubeDimentions.x));
                    }

                    randX = (int)math;
                    stairCase(Xstart, offset.y, lengthMade + spaceBetweenThings, staircaseSpaceX, staircaseSpaceZ, numOfBlocks, goLeft);
                    lengthMade += footPrintZ + spaceBetweenThings;
                }
            }
            else 
            {
                for (int i = 0; i < 5; i++)
                {
                    math = lengthMade / hardnessIncresse + 2;
                    if (math > MaxHardness) { math = MaxHardness; }
                    maker.setLevel((int)math);
                    maker.makeobs(new Vector3(offset.x, offset.y, lengthMade + spaceBetweenThings), Obs, obstaclePos);
                    footPrintZ = 7;
                    lengthMade += footPrintZ;
                }
            }
        }
    }
    void check()
    {
        if (cubeDimentions.x <= 0)
        {
            Debug.LogError("cube x not set or invalid value!");
            cubeDimentions.x = 1;
        }
        else if (cubeDimentions.y <= 0)
        {
            Debug.LogError("cube y not set or invalid value!");
            cubeDimentions.y = 1;
        }
        else if (cubeDimentions.z <= 0)
        {
            Debug.LogError("cube z not set or invalid value!");
            cubeDimentions.z = 1;
        }
        if (with <= 0)
        {
            Debug.Log("the with value may not be set or set incorrectly");
        }
        if (lenthOfTerain <= 0)
        {
            Debug.Log("the lenth of terain value may not be set or set incorrectly");
        }
        if (SpaceBetweenThings <= 0)
        {
            Debug.Log("the space between things value may not be set or set incorrectly");
            SpaceBetweenThings = with / 2;
            Debug.Log("Space between things has been set to: " + SpaceBetweenThings);
        }
        if (maxVeriation <= 0)
        {
            Debug.Log("the max veriation value may not be set or set incorrectly");
            maxVeriation = with / 2;
            Debug.Log("max veriation has been set to: " + maxVeriation);
        }
        if (maxHoleSpacing <= 0)
        {
            Debug.Log("the max hole spacing value may not be set or set incorrectly");
            maxHoleSpacing = with / 3;
            Debug.Log("max hole spacing has been set to: " + maxHoleSpacing);
        }
    }


    public void Start()
    {

        check();
        
        //previous.writeTo("test");
        levelMakerr(lenthOfTerain, SpaceBetweenThings);
        
    }
}

