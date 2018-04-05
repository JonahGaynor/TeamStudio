using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTriggerScript : MonoBehaviour {
    public GenericSectionSpawner spawnerToTrigger;
	// Use this for initialization
	void Start () {
        spawnerToTrigger = GameObject.Find("Generic Section Spawner").GetComponent<GenericSectionSpawner>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Little Boy")
        {
            spawnerToTrigger.spawnNextSection = true;
        }
    }
}
