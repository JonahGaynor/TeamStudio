using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixLaneChoiceGen : MonoBehaviour {
    bool shouldGenChoice = false;
    public GameObject[] levels;
    public float timeToSpawn = 3f;
    float maxTime = 3f;
    public bool hasSpawned=false;
    public bool spawnEnd = false;
    bool hasSpawnedEnd = false;
    public GameObject[] backgrounds;
    public GameObject floorParent;
    public GameObject bgParent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        shouldGenChoice = SixLaneGameController.Instance.startQuestion;
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn < 0)
        {
            timeToSpawn = maxTime;
           GameObject floor= Instantiate(levels[0]);
            Vector3 temp = floor.transform.position;
            temp.x = this.transform.position.x;
            floor.transform.position = temp;
            floor.transform.parent = floorParent.transform;
           
           GameObject bg= Instantiate(backgrounds[0]);
           
            temp = bg.transform.position;
            temp.x = this.transform.position.x;
            bg.transform.position = temp;
            bg.transform.parent = bgParent.transform;

        }
        if (shouldGenChoice&&!hasSpawned)
        {
            hasSpawned = true;
          
            if (SixLaneGameController.Instance.questionsAnswered > 4)
            {
                SixLaneGameController.Instance.questionsAnswered = 4;
            }
            GameObject question = Instantiate(levels[2 + SixLaneGameController.Instance.questionsAnswered]);
            Vector3 temp = question.transform.position;
            temp.x = this.transform.position.x;
            question.transform.position = temp;
        }
        if (SixLaneGameController.Instance.spawnFadePrefab&&!hasSpawnedEnd)
        {
            hasSpawnedEnd = true;
            GameObject question = Instantiate(levels[1]);
            
            Vector3 temp = question.transform.position;
            temp.x = this.transform.position.x;
            question.transform.position = temp;
        }
	}
}
