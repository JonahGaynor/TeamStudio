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
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnNextSection)
        {
           
            int choice;
            GameObject sectionToSpawn=null;
            if (sectionsSpawned < easySectionPrefabs.Length * difficultyIncreaseMultiplier)
            {
                choice = Random.Range(0, easySectionPrefabs.Length);
                sectionToSpawn = easySectionPrefabs[choice];
                sectionsSpawned++;
            }
            if (sectionsSpawned >= (easySectionPrefabs.Length * difficultyIncreaseMultiplier) && sectionsSpawned < ((easySectionPrefabs.Length* difficultyIncreaseMultiplier) +(mediumSectionPrefabs.Length * difficultyIncreaseMultiplier)))
            {
                choice = Random.Range(0, mediumSectionPrefabs.Length);
                sectionToSpawn = mediumSectionPrefabs[choice];
                sectionsSpawned++;
            }
            if (sectionsSpawned >= ((easySectionPrefabs.Length * difficultyIncreaseMultiplier) + (mediumSectionPrefabs.Length * difficultyIncreaseMultiplier)))
            {
                choice = Random.Range(0, hardSectionPrefabs.Length);
                sectionToSpawn = hardSectionPrefabs[choice];
                sectionsSpawned++;
            }
            GameObject placeSection = Instantiate(sectionToSpawn);
            Vector3 temp = placeSection.transform.position;
            temp.x = this.transform.position.x;
            placeSection.transform.position = temp;



            spawnNextSection = false;
        }
	}
}
