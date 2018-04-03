using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSceneGenerator : MonoBehaviour
{

    public GameObject player;
    public bool spawnObs = true;
    public bool spawnPlat = true;
    public bool spawnWall = true;
    int offset = 25;
    public GameObject platform;
    public GameObject platformParent;
    public GameObject obstacle;
    public GameObject floorPrefab;
    public GameObject floorParent;
    public GameObject bg;
	public GameObject bg2;
	public GameObject bg3;
	public GameObject bg4;
    public GameObject bgParent;
    public GameObject wallPrefab;
    GameObject background;
    GameObject exampleLane;
    public float[] lanes = { 0, 0, 0, 0};
    public float[] projectileLanes = { 0, 0, 0, 0,0};
    public float timeToSpawn = 1f;
    public float timeLeft = 1f;
    public float timeTillWall = 5f;
    public float timeTillBG = 1f;
    public float timeToSpawnGround = 1f;
    bool sameLanePicked = true;
    public int closePick, previousPick = -1, randomPick;
    public float ticksToProjectile = 1;
    
	string bgCheck;
    int prevOrder = -50;
    // Use this for initialization
    void Start()
    {
        timeToSpawn = 0.75f;
        for (int i = 0; i < lanes.Length; i++)
        {
            string stringToLookFor = "Platform " + (i + 1);
            exampleLane = GameObject.Find(stringToLookFor);
            lanes[i] = exampleLane.transform.position.y;
            projectileLanes[i] = lanes[i] + 1;
        }
        projectileLanes[4] = -6.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            if (!spawnPlat)
            {
                spawnPlat = true;
                return;
            }
            if (spawnPlat)
            {
                spawnPlat = false;
                return;
            }

        }
        if (Input.GetKeyDown(KeyCode.O))
        {

            if (!spawnObs)
            {
                spawnObs = true;
                return;
            }
            if (spawnObs)
            {
                spawnObs = false;
                return;
            }
        }
        sameLanePicked = true;
        timeLeft -= Time.deltaTime;
        Vector3 temp = this.transform.position;
        temp.x = player.transform.position.x + offset;
        this.transform.position = temp;
        //Spawn a Platform

        ticksToProjectile -= Time.deltaTime;

        if (timeLeft <= 0 && spawnPlat)
        {
            if (previousPick == -1) { previousPick = Random.Range(0, lanes.Length); }

            float tempNum = Random.Range(0f, 1.0f);
            if (previousPick == lanes.Length - 1) { tempNum = 0.55f; }
            if (previousPick == 0) { tempNum = 0; }
            if (tempNum > 0.5f) { closePick = previousPick - 1; }

            if (tempNum <= 0.5f) { closePick = previousPick + 1; }

            GameObject currentPlatform = Instantiate(platform);
            temp = currentPlatform.transform.position;
            temp.x = this.transform.position.x;
            temp.y = lanes[closePick];
            currentPlatform.transform.position = temp;
            currentPlatform.transform.parent = platformParent.transform;
            previousPick = closePick;
            //Spawn a platform in a random lane
            while (sameLanePicked)
            {
                randomPick = Random.Range(0, lanes.Length);
                if (randomPick != closePick && randomPick != closePick + 1 && randomPick != closePick - 1) { sameLanePicked = false; }
            }

            GameObject randomPlatform = Instantiate(platform);
            temp = randomPlatform.transform.position;
            temp.x = this.transform.position.x;
            temp.y = lanes[randomPick];
            randomPlatform.transform.position = temp;
            randomPlatform.transform.parent = platformParent.transform;
            timeLeft = timeToSpawn;
            // ticksToProjectile++;

        }
        if (ticksToProjectile < 0 && spawnObs)
        {
           
            
            ticksToProjectile =3;
            int pick = Random.Range(0, projectileLanes.Length);
            // Debug.Log(pick);
            GameObject currentObstacle = Instantiate(obstacle);
            temp = currentObstacle.transform.position;
            temp.y = projectileLanes[pick];
            temp.x = this.transform.position.x;
            currentObstacle.transform.position = temp;
            if (pick != 0)
            {
                float additionalProjectileChance = Random.Range(0f, 1f);
                if (additionalProjectileChance > 0.3)
                {
                   
                    GameObject botObstacle = Instantiate(obstacle);
                    temp = botObstacle.transform.position;
                    temp.y = projectileLanes[4];
                    temp.x = this.transform.position.x;
                    botObstacle.transform.position = temp;
                }
            }
        }
        if (timeTillWall < 0 && spawnWall)
        {
            timeTillWall = 5;
            float wallPlacement=Random.Range(-5.44f, 0);
            GameObject currentObstacle = Instantiate(wallPrefab);
            temp = currentObstacle.transform.position;
            temp.y = wallPlacement;
            temp.x = this.transform.position.x;
            currentObstacle.transform.position = temp;

        }

        timeTillBG -= Time.deltaTime;
        timeToSpawnGround -= Time.deltaTime;
        timeTillWall -= Time.deltaTime;
        if (timeToSpawnGround < 0)
        {
            timeToSpawnGround = 2f;

            //Spawn Floor
            GameObject floor = Instantiate(floorPrefab);
            Vector3 tempFloor = floor.transform.position;
            tempFloor.x = this.transform.position.x;
            floor.transform.position = tempFloor;
            floor.transform.parent = floorParent.transform;
          //  Debug.Log("Spawned Floor");
            //Spawn BG
			
        }
        if (timeTillBG < 0)
        {
            timeTillBG = 1f;

            float myRand = Random.value;
            if (myRand <= 0.15f && bgCheck != "Swings")
            {
                background = Instantiate(bg);
                background.GetComponent<SpriteRenderer>().sortingOrder = -50;
                bgCheck = "Swings";
            }
            else if (myRand <= 0.65f)
            {
                background = Instantiate(bg2);
                bgCheck = "";
                background.GetComponent<SpriteRenderer>().sortingOrder = prevOrder;
            }
            else if (myRand <= 0.8f)
            {
                background = Instantiate(bg3);
                bgCheck = "";
                background.GetComponent<SpriteRenderer>().sortingOrder = prevOrder;
            }
            else
            {
                background = Instantiate(bg4);
                bgCheck = "";
                background.GetComponent<SpriteRenderer>().sortingOrder = prevOrder;
            }
            Vector3 temp1 = background.transform.position;
            temp1.x = this.transform.position.x;
            background.transform.position = temp1;
            background.transform.parent = bgParent.transform;

            prevOrder--;
        }




    }
}


