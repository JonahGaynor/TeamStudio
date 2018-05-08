using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReconnectionGameController : MonoBehaviour {
    public static ReconnectionGameController Instance = new ReconnectionGameController();
    public float love=10;
    public float timeToEvent=4f;
    public float timeLeftTillEvent;
    public Sprite[] flashBackImages;
    public KeyCode requiredKey;
    public string[] possibleKeys = { "A", "S", "D", "F", "W" };
    public GameObject stupidKid;
    public int sectionsPast = 0;
	// Use this for initialization
	void Start () {
        Instance = this;
        timeLeftTillEvent = timeToEvent;
        

	}
	
	// Update is called once per frame
	void Update () {
        timeLeftTillEvent -= Time.deltaTime;
        timeToEvent = 4 - (sectionsPast / 5);
        if (timeLeftTillEvent < 0)
        {
            timeLeftTillEvent = timeToEvent;
            GameObject currentObstacle =new GameObject("Image Prompt");
            currentObstacle.AddComponent<SpriteRenderer>();
            currentObstacle.GetComponent<SpriteRenderer>().sprite = flashBackImages[Random.Range(0, flashBackImages.Length)];
          //  currentObstacle.name = currentObstacle.GetComponent<SpriteRenderer>().sprite.name;
            currentObstacle.transform.position = stupidKid.transform.position;
            currentObstacle.AddComponent<FlashbackObjectScript>();
            currentObstacle.GetComponent<SpriteRenderer>().sortingOrder = 10;
           GameObject textMeshChild= new GameObject("Text Mesh Child");
            textMeshChild.AddComponent<TextMesh>();
            textMeshChild.GetComponent<TextMesh>().text = possibleKeys[Random.Range(0, possibleKeys.Length)];
            textMeshChild.GetComponent<MeshRenderer>().sortingOrder = 25;
            textMeshChild.GetComponent<TextMesh>().color = Color.red;
            textMeshChild.transform.localScale = new Vector3(0.14f, 0.14f, 1);
            textMeshChild.GetComponent<TextMesh>().fontSize = 100;
            Vector3 temp = currentObstacle.transform.position;
            temp.y += 3;
            temp.z = 20;
            currentObstacle.transform.position = temp;

            textMeshChild.transform.localPosition = temp;
            textMeshChild.transform.localPosition += new Vector3(-0.63f, 0.67f, 0);
            textMeshChild.transform.parent = currentObstacle.transform;
          
        }
	}


    public KeyCode DetermineKeyToPress(string key)
    {
        if (key == "A")
        {
            return KeyCode.A;
        }
        if (key == "S")
        {
            return KeyCode.S;
        }
        if (key == "D")
        {
            return KeyCode.D;
        }
        if (key == "F")
        {
            return KeyCode.F;
        }
        if (key == "W")
        {
            return KeyCode.W;
        }
        return KeyCode.Return;
    }
}
