using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceChoicesScript : MonoBehaviour {
    public static ChoiceChoicesScript Instance = new ChoiceChoicesScript();
    public Image upperChoice;
    public Image lowerChoice;
    public Sprite[] upperChoicePics;
    public Sprite[] lowerChoicePics;
    public int choiceNum;
    public float choiceTimer = 15f;
    public bool withinThreshold;
    public bool atChoice = false;
	// Use this for initialization
	void Start () {
        Instance = this;
        
        lowerChoice.gameObject.SetActive(false);
        upperChoice.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (withinThreshold)
        {
            choiceTimer -= Time.deltaTime;
            if (choiceTimer - Mathf.Floor(choiceTimer) > 0.5)
            {
                upperChoice.gameObject.SetActive(true);
                lowerChoice.gameObject.SetActive(true);
            }
            else
            {
                upperChoice.gameObject.SetActive(false);
                lowerChoice.gameObject.SetActive(false);
            }
            if (atChoice)
            {
                upperChoice.gameObject.SetActive(false);
                lowerChoice.gameObject.SetActive(false);
                choiceTimer = 5f;
                withinThreshold = false;
                atChoice = false;
                choiceNum++;
            }
        }
        
        lowerChoice.sprite = lowerChoicePics[0];
        upperChoice.sprite = upperChoicePics[0];
    }
}
