using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveGenerator : MonoBehaviour
{

    public GameObject player;
    int offset = 25;
    public GameObject[] walls;
    public GameObject wallParent;

    public GameObject batteryPickup;
   
    public float timeToSpawn = 1f;
    public float timeLeft = 1f;

    bool sameLanePicked = true;
    public int closePick, previousPick = -1, randomPick, ticksToProjectile, tickToPowerUp;
    // Use this for initialization
    void Start()
    {
        timeToSpawn = 2f;
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
        if (timeLeft <= 0)
        {

            int tempNum = Random.Range(0, walls.Length);
            GameObject currentWall = Instantiate(walls[tempNum]);
            temp = currentWall.transform.position;
            temp.x = this.transform.position.x;
            currentWall.transform.position = temp;
            currentWall.transform.parent = wallParent.transform;
            previousPick = closePick;
            timeLeft = timeToSpawn;
            ticksToProjectile++;
            tickToPowerUp++;

        }
      
        if (tickToPowerUp == 3)
        {

            float pickY = Random.Range(-3.2f, 4f);
            // Debug.Log(pick);
            GameObject battery = Instantiate(batteryPickup);
            temp = battery.transform.position;
            temp.y = pickY;
            temp.x = this.transform.position.x;
            battery.transform.position = temp;
            tickToPowerUp = 0;
        }

    }
}


