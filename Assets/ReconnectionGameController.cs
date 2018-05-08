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
    string[] possibleKeys = { "A", "S", "D", "W" };
    public GameObject stupidKid;
    public Animator kidAnim;
    public int sectionsPast = 0;
    public float timeTillThrow;
    public float maxTimeToThrow;
    public GameObject lineExample;
	// Use this for initialization
	void Start () {
        Instance = this;
        timeLeftTillEvent = timeToEvent;
        maxTimeToThrow = timeToEvent - 0.25f;
        kidAnim = stupidKid.GetComponent<Animator>();
        timeTillThrow = maxTimeToThrow;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeftTillEvent -= Time.deltaTime;
        timeTillThrow -= Time.deltaTime;
        timeToEvent = 4 - (sectionsPast / 5);
        maxTimeToThrow = timeToEvent - 0.25f;

        if (timeTillThrow < 0)
        {
            kidAnim.SetTrigger("ShouldThrow");
            //kidAnim.SetBool("ShouldRun",false);
            timeTillThrow = maxTimeToThrow;



        }


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
            temp.y += 2.5f;
            temp.z = 20;
            currentObstacle.transform.position = temp;

            textMeshChild.transform.localPosition = temp;
            textMeshChild.transform.localPosition += new Vector3(-0.63f, 4.75f, 0);
            textMeshChild.transform.parent = currentObstacle.transform;
            //  kidAnim.SetBool("ShouldRun", true);
            timeTillThrow = maxTimeToThrow;
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
       
        if (key == "W")
        {
            return KeyCode.W;
        }
        return KeyCode.Return;
    }
    public KeyCode[] DetermineKeysNotToPress(KeyCode key)
    {
        KeyCode[] stupid =new KeyCode[4];
        if (key == KeyCode.A)
        {
            KeyCode[] returner = { KeyCode.S , KeyCode.D, KeyCode.W};
            return returner;
        }
        if (key == KeyCode.S)
        {
            KeyCode[] returner = { KeyCode.A, KeyCode.D, KeyCode.W };
            return returner;
        }
        if (key == KeyCode.D)
        {
            KeyCode[] returner = { KeyCode.S, KeyCode.A,  KeyCode.W };
            return returner;
        }
      
        if (key == KeyCode.W)
        {
            KeyCode[] returner = { KeyCode.S, KeyCode.D, KeyCode.A };
            return returner;
        }
        return stupid;
    }
}
