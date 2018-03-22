using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKGGenerator : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject[] blipsToSpawn;
    public GameObject bg;
    public float timeToSpawn = 2f;
    float maxTime = 4f;
   public float timeTillBlip = 1.5f;
    float maxBlipTimer = 1.5f;
    public GameObject floorParent;
    public GameObject bgParent;
    Vector3 convert;
    void Update()
    {       
        timeToSpawn -= Time.deltaTime;
        timeTillBlip -= Time.deltaTime;
        if (timeToSpawn < 0)
        {
            timeToSpawn = maxTime;

            //Spawn Floor
            GameObject floor = Instantiate(floorPrefab);
            Vector3 temp = floor.transform.position;
            temp.x = this.transform.position.x+135;        
            floor.transform.position = temp;
            floor.transform.parent = floorParent.transform;

            //Spawn BG
            GameObject background = Instantiate(bg);
            Vector3 temp1 = background.transform.position;
            temp1.x = this.transform.position.x + 135;
            background.transform.position = temp1;
            background.transform.parent = bgParent.transform;
        }
        if (timeTillBlip < 0)
        {
            timeTillBlip = maxBlipTimer;
            GameObject blip = Instantiate(blipsToSpawn[Random.Range(0,blipsToSpawn.Length)]);
            Vector3 temp = blip.transform.position;
            temp.x = this.transform.position.x;
            blip.transform.position = temp;
        }
    }
}
