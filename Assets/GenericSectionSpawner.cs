using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSectionSpawner : MonoBehaviour {
    public GameObject[] easySectionPrefabs;
    public GameObject[] mediumSectionPrefabs;
    public GameObject[] hardSectionPrefabs;
    public int sectionsSpawned = 0;
    public bool spawnNextSection=true;
    public float difficultyIncreaseMultiplier = 2;
    public GameObject[] clouds;
    public GameObject bg;
    public GameObject bg2;
    public GameObject bg3;
    public GameObject bg4;
    public GameObject bgParent;
    public GameObject floorPrefab;
    public GameObject ceilingPrefab;
    public GameObject floorParent;
    public float timeToSpawnGround = 1f;
    public bool spawnCloud = false;
    public float timeTillBG = 1f;
    public bool spawnBG = true;
    public bool canMakeSpecialBG = true;
    public bool inDebugMode = false;

    public bool canMakeCeiling = false;
    int prevOrder = -50;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeTillBG -= Time.deltaTime;
        timeToSpawnGround -= Time.deltaTime;
       
        if (spawnNextSection&&!inDebugMode)
        {
           
            int choice;
            GameObject sectionToSpawn=null;
            if (sectionsSpawned < easySectionPrefabs.Length * difficultyIncreaseMultiplier)
            {
                choice = Random.Range(0, easySectionPrefabs.Length);
                sectionToSpawn = easySectionPrefabs[choice];

            }
            if (sectionsSpawned >= (easySectionPrefabs.Length * difficultyIncreaseMultiplier) && sectionsSpawned < ((easySectionPrefabs.Length* difficultyIncreaseMultiplier) +(mediumSectionPrefabs.Length * difficultyIncreaseMultiplier)))
            {
                choice = Random.Range(0, mediumSectionPrefabs.Length);
                sectionToSpawn = mediumSectionPrefabs[choice];

            }
            if (sectionsSpawned >= ((easySectionPrefabs.Length * difficultyIncreaseMultiplier) + (mediumSectionPrefabs.Length * difficultyIncreaseMultiplier)))
            {
                choice = Random.Range(0, hardSectionPrefabs.Length);
                sectionToSpawn = hardSectionPrefabs[choice];
                
            }
            GameObject placeSection = Instantiate(sectionToSpawn);
            Vector3 temp = placeSection.transform.position;
            temp.x = this.transform.position.x;
            placeSection.transform.position = temp;
            sectionsSpawned++;


            spawnNextSection = false;
        }

        if (timeTillBG < 0 && spawnBG)
        {
            timeTillBG = 1f;
            float shouldSpawnForeground = Random.Range(0, 1f);
            float myRand = Random.value;
            GameObject foreground = null;
            if (shouldSpawnForeground <= 0.15f && canMakeSpecialBG)
            {
                foreground = Instantiate(bg);
                foreground.GetComponent<SpriteRenderer>().sortingOrder = prevOrder + 1;
                canMakeSpecialBG = false;
            }
            else if (shouldSpawnForeground <= 0.3f && canMakeSpecialBG)
            {
                foreground = Instantiate(bg2);
                canMakeSpecialBG = false;
                foreground.GetComponent<SpriteRenderer>().sortingOrder = prevOrder + 1;
            }
            else
            {
                spawnCloud = true;
                canMakeSpecialBG = true;
            }
            GameObject boringBackground = Instantiate(bg4);
            boringBackground.GetComponent<SpriteRenderer>().sortingOrder = prevOrder - 1;
            Vector3 temp1 = boringBackground.transform.position;
            temp1.x = this.transform.position.x+10;
            boringBackground.transform.position = temp1;
            boringBackground.transform.parent = bgParent.transform;
            if (foreground != null)
            {
                temp1 = foreground.transform.position;
                temp1.x = this.transform.position.x+10;
                foreground.transform.position = temp1;
                foreground.transform.parent = bgParent.transform;
            }

        }
        if (timeToSpawnGround < 0)
        {

            if (!canMakeCeiling)
            {
                timeToSpawnGround = 2f;
            }
            //Spawn Floor
            GameObject floor = Instantiate(floorPrefab);
            Vector3 tempFloor = floor.transform.position;
            tempFloor.x = this.transform.position.x;
            floor.transform.position = tempFloor;
            floor.transform.parent = floorParent.transform;
            //Spawn BG

        }
        if (timeToSpawnGround < 0&&canMakeCeiling)
        {
            timeToSpawnGround = 2f;
            //Spawn Floor
            GameObject floor = Instantiate(ceilingPrefab);
            Vector3 tempFloor = floor.transform.position;
            tempFloor.x = this.transform.position.x;
            floor.transform.position = tempFloor;
            floor.transform.parent = floorParent.transform;
            //Spawn BG

        }
        if (spawnCloud && !inDebugMode)
        {
            spawnCloud = false;
            if (Random.Range(0, 3) == 1)
            {
               
                GameObject cloudtoSpawn = Instantiate(clouds[Random.Range(0, clouds.Length)]);
                cloudtoSpawn.GetComponent<SpriteRenderer>().sortingOrder = prevOrder;
                Vector3 temp = cloudtoSpawn.transform.position;
                temp.x = this.transform.position.x + 10;
                cloudtoSpawn.transform.position = temp;
                cloudtoSpawn.transform.parent = bgParent.transform;
            }
            
        }
    }
}
