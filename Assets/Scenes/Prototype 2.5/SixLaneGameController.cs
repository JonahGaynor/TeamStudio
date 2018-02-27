using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixLaneGameController : MonoBehaviour {



    public static SixLaneGameController Instance = new SixLaneGameController();
    public int life = 10;
    public bool startQuestion = false;
    public float standardMoveSpeed = 0.350f;
    public bool gameOver = false;
    public float timeToWait = 2;
    public bool fadeToEnd = false;
    public float timeToEnd = 5;
    public bool topChoiceMade = false;
    public bool bottomChoiceMade = false;
    public bool moveToNextLevel = false;
    public int levelsPast = 0;
    public int questionsAnswered;
    public bool stopSpawning = false;
    public bool spawnFadePrefab = false;
	public bool weWon = false;
    public float timeTillNextQuestion = 15f;
    int currentQuestion = 0;
    public GameObject[] questionPrompt;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        life = 10;
   		Instance = this;
        standardMoveSpeed = 0.150f;
		questionsAnswered = 3;

        // standardMoveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startQuestion)
        {
            timeTillNextQuestion -= Time.deltaTime;
        }
        if (moveToNextLevel)
        {
            questionsAnswered = 0;
        }
       // if (questionsAnswered == 3)
        //{
       //     spawnFadePrefab = true;
      //  }
        
       
        if (timeTillNextQuestion < 0 && currentQuestion == questionsAnswered)
        {
            currentQuestion++;
            startQuestion = true;
            timeTillNextQuestion = 15f;
        }
      
        
      
    }
}


