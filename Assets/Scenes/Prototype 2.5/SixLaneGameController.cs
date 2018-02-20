using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixLaneGameController : MonoBehaviour {



    public static SixLaneGameController Instance = new SixLaneGameController();
    public int life = 10;
    public bool startQuestion = false;
    public float standardMoveSpeed = 0.175f;
    public bool gameOver = false;
    public float timeToWait = 2;
    public bool fadeToEnd = false;
    public float timeToEnd = 5;
    public bool topChoiceMade = false;
    public bool bottomChoiceMade = false;
    public bool moveToNextLevel = false;
    public int levelsPast = 0;
    public int questionsAnswered = 0;
    public bool stopSpawning = false;
    public bool spawnFadePrefab = false;
    public float timeTillNextQuestion = 15f;
    int currentQuestion = 0;
    public GameObject[] questionPrompt;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
           life = 10;
    Instance = this;
        standardMoveSpeed = 0.075f;
        // standardMoveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timeTillNextQuestion -= Time.deltaTime;
        if (moveToNextLevel)
        {
            questionsAnswered = 0;
        }
        if (questionsAnswered == 4)
        {
            spawnFadePrefab = true;
        }
        
       
        if (timeTillNextQuestion < 0 && currentQuestion == questionsAnswered)
        {
            currentQuestion++;
            startQuestion = true;
            timeTillNextQuestion = 15f;
        }
      
    }
}


