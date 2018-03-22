using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKGGenerator : MonoBehaviour
{
    public GameObject floorPrefab;
    public float timeToSpawn = 2f;
    float maxTime = 4f;  
    public GameObject floorParent;
    Vector3 convert;
    void Update()
    {       
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn < 0)
        {
            timeToSpawn = maxTime;
            GameObject floor = Instantiate(floorPrefab);
            Vector3 temp = floor.transform.position;
            temp.x = this.transform.position.x+135;        
            floor.transform.position = temp;
            floor.transform.parent = floorParent.transform;
        }       
    }
}
