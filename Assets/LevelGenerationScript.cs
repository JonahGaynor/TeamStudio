using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerationScript : MonoBehaviour {
    bool shouldGenChoice = false;
    public GameObject[] levels;
    float timeToSpawn = 3f;
    float maxTime = 3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn == 0)
        {
            timeToSpawn = maxTime;
            Instantiate(levels[0], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        }
        if (shouldGenChoice)
        {
            Instantiate(levels[1], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        }
	}
}
