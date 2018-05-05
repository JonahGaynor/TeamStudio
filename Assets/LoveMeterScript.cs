using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveMeterScript : MonoBehaviour {
    public float endSpot;
    public float startSpot;
    public float placeToBe;
    public GameObject myFace;
    // Use this for initialization
    void Start () {
        startSpot = GameObject.Find("StartSpot").GetComponent<Transform>().position.y;
        endSpot = GameObject.Find("EndSpot").GetComponent<Transform>().position.y;
        myFace = GameObject.Find("Moving Face");
        placeToBe = myFace.transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        placeToBe = RecconectController.Instance.love;
        if (myFace.transform.position.x < placeToBe)
        {
            Vector3 temp = myFace.transform.position;
            temp.x += 0.0001f;
        }
        if (myFace.transform.position.x > placeToBe)
        {
            Vector3 temp = myFace.transform.position;
            temp.x -= 0.0001f;
        }
    }
}
