using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour {
    public GameObject player;
     int offset = 25;
    public GameObject[] furniture;
    public float timeToSpawn=4f;
    public float timeLeft = 2f;
    public int pick;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        Vector3 temp = this.transform.position;
        temp.x = player.transform.position.x + offset;
        this.transform.position = temp;
        if (timeLeft <= 0&&!GameController.Instance.hitText)
        {
            pick = Random.Range(0, furniture.Length);
           GameObject pickedObject= Instantiate(furniture[pick]);
            temp = pickedObject.transform.position;
            temp.x = this.transform.position.x;
            pickedObject.transform.position = temp;
            timeLeft = timeToSpawn;

        }
        if (GameController.Instance.hitText)
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Furniture");
            foreach (GameObject furniture in obstacles)
            {
                Destroy(furniture.gameObject);
            }
        }


    }
}
