using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixLaneGenerator : MonoBehaviour {

    public GameObject player;
    int offset = 25;
    public GameObject platform;
    public GameObject platformParent;
    public GameObject obstacle;
    GameObject exampleLane;
    public float[] lanes = { 0,0,0,0,0,0 };
     float[] projectileLanes = { 0, 0, 0, 0, 0, 0 ,0};
    public float timeToSpawn = 1f;
    public float timeLeft = 1f;
    
    bool sameLanePicked = true;
    public int closePick, previousPick=-1, randomPick,ticksToProjectile;
    // Use this for initialization
    void Start()
    {
        timeToSpawn = 0.75f;
        for (int i=0; i<lanes.Length; i++)
        {
            string stringToLookFor = "Platform " +( i + 1);
             exampleLane = GameObject.Find(stringToLookFor);
            lanes[i] = exampleLane.transform.position.y;
            projectileLanes[i] = lanes[i] + 0.7f;
        }
        projectileLanes[6] =-3.82f;
    }

    // Update is called once per frame
    void Update()
    {
        sameLanePicked = true;
        timeLeft -= Time.deltaTime;
        Vector3 temp = this.transform.position;
        temp.x = player.transform.position.x + offset;
        this.transform.position = temp;
        //Spawn a Platform
        if (timeLeft <= 0&&!SixLaneGameController.Instance.startQuestion)
        {
            if (previousPick == -1) { previousPick = Random.Range(0, lanes.Length); }

            float tempNum = Random.Range(0f, 1.0f);
            if (previousPick == lanes.Length - 1) { tempNum =0.55f; }
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
                if (randomPick != closePick&& randomPick != closePick+1 && randomPick != closePick - 1) { sameLanePicked = false; }
            }

            GameObject randomPlatform = Instantiate(platform);
            temp = randomPlatform.transform.position;
            temp.x = this.transform.position.x;
            temp.y = lanes[randomPick];
            randomPlatform.transform.position = temp;
            randomPlatform.transform.parent = platformParent.transform;
            timeLeft = timeToSpawn;
            ticksToProjectile++;

        }
        if (ticksToProjectile == 1)
        {
            
            int pick = Random.Range(0, projectileLanes.Length);
           // Debug.Log(pick);
            GameObject currentObstacle = Instantiate(obstacle);
             temp = currentObstacle.transform.position;
            temp.y = projectileLanes[pick];
            temp.x = this.transform.position.x;
            currentObstacle.transform.position = temp;
            ticksToProjectile = 0;
        }

    }
}


