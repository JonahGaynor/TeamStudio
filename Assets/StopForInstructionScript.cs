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
       
        Time.timeScale = 1;
		if (timeSinceStarting >timeAtWhichToStop && PlayerPrefs.GetInt ("hasSeenInstructions") != 1)
        {
            isStopped = true;
            timeAtWhichToStop = 5000000000000000000000000000000f;
        }
		if (isStopped) {
			GameObject.Find ("Little Boy").GetComponent<DashScript> ().canDash = false;
			instuctionCanvas.enabled = true;
			Time.timeScale = 0;
                
		}
        if (Input.GetKeyDown(KeyCode.Space))
        {
			GameObject.Find ("Little Boy").GetComponent<DashScript> ().canDash = true;
            isStopped = false;
			PlayerPrefs.SetInt ("hasSeenInstructions", 1);
        }
		if (ProofGameController.Instance.moveToNextLevel) {
			PlayerPrefs.SetInt ("hasSeenInstructions", 0);
		}
    }
}
