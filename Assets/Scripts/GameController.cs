using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController Instance = new GameController();
    public int life=50;
    public bool startQuestion = false;
    public float standardMoveSpeed = 0.175f;
    public bool gameOver = false;
    public bool hitText = false;
    public GameObject wallOfText;
    public float timeToWait = 2;
    public bool escapeTime=false;
    public bool atFuneral = false;
    public bool fadeToEnd=false;
    public float timeToEnd = 5;
    public bool topChoiceMade = false;
    public bool bottomChoiceMade = false;
    public bool moveToNextLevel = false;
    public int levelsPast = 0;
    public int questionsAnswered = 0;
    public bool stopSpawning = false;
    public float timeTillNextQuestion = 15f;
    int currentQuestion=0;
    public GameObject[] questionPrompt;
    public GameObject player;
	// Use this for initialization
	void Start () {
        Instance = this;
        standardMoveSpeed = 0.175f;
    }
	
	// Update is called once per frame
	void Update () {
        if (hitText)
        {
            timeToWait -= Time.deltaTime;
            if (timeToWait <= 0)
            {
                escapeTime = true;
                wallOfText.gameObject.SetActive(false);
            }
        }
        if (currentQuestion == questionsAnswered) { timeTillNextQuestion -= Time.deltaTime; }
        if (timeTillNextQuestion < 0&& currentQuestion==questionsAnswered)
        {
            currentQuestion++;
            GameObject prompt=Instantiate(questionPrompt[questionsAnswered]);
            Vector3 temp = prompt.transform.position;
            temp.x = player.transform.position.x + 20;
            prompt.transform.position = temp;
            timeTillNextQuestion = 15f;
        }
        if (atFuneral)
        {
            
            standardMoveSpeed = Mathf.Lerp(standardMoveSpeed, 0, 0.0075f);
            life = 1;
            timeToEnd -= Time.deltaTime;
            if (timeToEnd <= 0)
            {
                fadeToEnd = true;
            }
        }
	}
}
