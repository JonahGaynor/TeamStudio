using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeLifeManager : MonoBehaviour {
    public static HomeLifeManager Instance = new HomeLifeManager();
	public float stressLevel=0;
	public float stressMultiplier = 0.25f;
	public float maxStress = 30f;
	public int collectiblesGot = 0;
	public float myTimer = 0f;
	public static float firstCheckpoint = 20f;
	public static float secondCheckpoint = 40f;
	bool firstCheckpointHit = false;
	bool secondCheckpointHit = false;
	public Animator[] characterAnimators;
	public GameObject myPlayer;
	Animator myAnimator;
    public Canvas calendarCanvas;
    Vector3 calendarStart;
    public bool inCalendarCoroutine = false;
    public bool canChangeAnim=false;
    // Use this for initialization
    void Start () {
        Instance = this;
		myPlayer = GameObject.Find ("Little Boy");
		myAnimator = myPlayer.GetComponent<Animator> ();
        myAnimator.SetLayerWeight(1, 0);
        myAnimator.SetLayerWeight(2, 0);
        calendarStart = calendarCanvas.transform.GetChild(0).transform.position;
        //myAnimator = characterAnimators [0];
    }
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(stressLevel);
        stressLevel += Time.deltaTime * stressMultiplier;
		myTimer += Time.deltaTime;

		if (stressLevel >= maxStress && !secondCheckpointHit) {
			ProofGameController.Instance.gameOver = true;
		} else if (stressLevel >= maxStress && secondCheckpointHit) {
			ProofGameController.Instance.moveToNextLevel = true;
		}
		if (myTimer >= firstCheckpoint && !firstCheckpointHit) {
			
            StartCoroutine(TimePasses());
            if (canChangeAnim)
            {
                firstCheckpointSwitch();
                canChangeAnim = false;
                firstCheckpointHit = true;
                stressLevel = 1;
            }
           
		}
		if (myTimer >= secondCheckpoint && firstCheckpointHit && !secondCheckpointHit) {
			
			
            StartCoroutine(TimePasses());

            if (canChangeAnim)
            {
                secondCheckpointSwitch();
                canChangeAnim = false;
                secondCheckpointHit = true;
                stressLevel = 1;
            }
           
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            firstCheckpointSwitch();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            secondCheckpointSwitch();
        }
    }

	void firstCheckpointSwitch () {
        myAnimator.SetLayerWeight(0, 0);
        myAnimator.SetLayerWeight(1, 100);
        //myAnimator = characterAnimators [1];
    }

	void secondCheckpointSwitch () {
        myAnimator.SetLayerWeight(1, 0);
        myAnimator.SetLayerWeight(2, 100);
        //	myAnimator = characterAnimators [2];
    }
    IEnumerator TimePasses()
    {
        float timeToWipe = 5f;
        if (!inCalendarCoroutine)
        {
            GameObject calendarImage = calendarCanvas.transform.GetChild(0).gameObject;
            inCalendarCoroutine = true;
            while (inCalendarCoroutine)
            {
                              
                Vector3 temp = calendarImage.transform.position;
                temp.x -=16f;
                temp.y -=8f;
                timeToWipe -= Time.deltaTime;
               
                calendarImage.transform.position = temp;
                if (timeToWipe < 0)
                {
                    
                    inCalendarCoroutine = false;
                    calendarImage.transform.position = calendarStart;
                }
                if (timeToWipe < 4f)
                {
                    canChangeAnim = true;
                }
                yield return new WaitForSeconds(1 / 60);
            }
        }
        yield return new WaitForSeconds(1/60);

    }

}
