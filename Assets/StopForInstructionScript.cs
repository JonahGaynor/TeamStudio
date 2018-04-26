using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopForInstructionScript : MonoBehaviour {
    public bool isStopped = false;
    public float timeSinceStarting=0;
    public Canvas instuctionCanvas;
    public float timeAtWhichToStop = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        instuctionCanvas.enabled = false;
        timeSinceStarting += Time.deltaTime;
        Debug.Log(Time.timeScale);
        Time.timeScale = 1;
        if (timeSinceStarting >timeAtWhichToStop)
        {
            isStopped = true;
            timeAtWhichToStop = 5000000000000000000000000000000f;
        }
        if (isStopped)
        {
            instuctionCanvas.enabled = true;
            Time.timeScale = 0;
                
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStopped = false;
        }
    }
}
