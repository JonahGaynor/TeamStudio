using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerationScript : MonoBehaviour {
    bool shouldGenChoice = false;
    public GameObject[] levels;
    public float timeToSpawn = 3f;
    float maxTime = 3f;
    public bool hasSpawned=false;
    bool hasSpawnedEnd = false;
    public GameObject[] backgrounds;
    public GameObject floorParent;
    public GameObject bgParent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        shouldGenChoice = GameController.Instance.startQuestion;
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn < 0)
        {
            timeToSpawn = maxTime;
           GameObject floor= Instantiate(levels[0]);
            Vector3 temp = floor.transform.position;
            temp.x = this.transform.position.x;
            floor.transform.position = temp;
            floor.transform.parent = floorParent.transform;
            int choice = Random.Range(0, backgrounds.Length);
           GameObject bg= Instantiate(backgrounds[choice]);
           
            temp = bg.transform.position;
            temp.x = this.transform.position.x;
            bg.transform.position = temp;
            bg.transform.parent = bgParent.transform;
          //  bg.transform.parent = this.gameObject.transform;
        }
        if (shouldGenChoice&&!hasSpawned&&GameController.Instance.questionsAnswered<4&&GameController.Instance.startQuestion)
        {
            hasSpawned = true;
           GameObject question= Instantiate(levels[1]);
            Vector3 temp = question.transform.position;
            temp.x = this.transform.position.x;
            question.transform.position = temp;
        }
        if (GameController.Instance.spawnFadePrefab&&!hasSpawnedEnd)
        {
            hasSpawnedEnd = true;
            GameObject question = Instantiate(levels[2]);
            
            Vector3 temp = question.transform.position;
            temp.x = this.transform.position.x;
            question.transform.position = temp;
        }
	}
}
