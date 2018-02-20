using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixLaneGenerator : MonoBehaviour {

    public GameObject player;
    int offset = 25;
    public GameObject platform;
    public GameObject platformParent;
    GameObject exampleLane;
    public float[] lanes = { -2.5f,-0.5f, 1.5f, 3.5f,5.5f, 7.5f };
    public float timeToSpawn = 1f;
    public float timeLeft = 1f;
    bool sameLanePicked = true;
    public int closePick, previousPick=-1, randomPick;
    // Use this for initialization
    void Start()
    {
        timeToSpawn = 0.75f;
        for (int i=0; i<lanes.Length; i++)
        {
            string stringToLookFor = "Platform " +( i + 1);
             exampleLane = GameObject.Find(stringToLookFor);
            lanes[i] = exampleLane.transform.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        sameLanePicked = true;
        timeLeft -= Time.deltaTime;
        Vector3 temp = this.transform.position;
        temp.x = player.transform.position.x + offset;
        this.transform.position = temp;
        if (timeLeft <= 0)
        {
            if (previousPick == -1) { previousPick = Random.Range(0, lanes.Length); }

            float tempNum = Random.Range(0f, 1.0f);
            if (previousPick == lanes.Length - 1) { tempNum =0.55f; }
            if (previousPick == 0) { tempNum = 0; }
            if (tempNum > 0.5f) { closePick = previousPick - 1; }

            if (tempNum <= 0.5f) { closePick = previousPick + 1; }
            Debug.Log(tempNum);
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
                if (randomPick != closePick) { sameLanePicked = false; }
            }

            GameObject randomPlatform = Instantiate(platform);
            temp = randomPlatform.transform.position;
            temp.x = this.transform.position.x;
            temp.y = lanes[randomPick];
            randomPlatform.transform.position = temp;
            randomPlatform.transform.parent = platformParent.transform;
            timeLeft = timeToSpawn;

        }

    }
}


