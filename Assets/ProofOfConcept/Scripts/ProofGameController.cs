using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProofGameController : MonoBehaviour {



	public static ProofGameController Instance = new ProofGameController();
    public int life = 10;
    public bool startQuestion = false;
    public float standardMoveSpeed = .18f;
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
    public float timeTillNextQuestion;
    int currentQuestion = 3;
    public GameObject[] questionPrompt;
    public GameObject player;
    int prevPickups;
    public int numPickups = 0;
    AudioSource deathSound;
    // Use this for initialization
    private void Awake()
    {
        moveToNextLevel = false;
    }
    void Start()
    {
        moveToNextLevel = false;
        deathSound = this.GetComponent<AudioSource>();
        life = 3;
   		Instance = this;
        //standardMoveSpeed = 0.0005f;
		questionsAnswered = 2;
		timeTillNextQuestion = 5f;

        // standardMoveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0)
        {
            gameOver = true;
        }
        if (prevPickups != numPickups)
        {
            life++;
            prevPickups = numPickups;
        }

        if (!startQuestion)
        {
            timeTillNextQuestion -= Time.deltaTime;
        }
        if (moveToNextLevel)
        {
            questionsAnswered = 0;
        }
        if (questionsAnswered == 3)
        {
            spawnFadePrefab = true;
        }
        
       
        if (timeTillNextQuestion < 0 && currentQuestion == questionsAnswered)
        {
            currentQuestion++;
            startQuestion = true;
            timeTillNextQuestion = 15f;
        }

        if (fadeToEnd)
        {
//            AudioClip myClip = deathSound.clip;
//            deathSound.PlayOneShot(myClip);
        }
      
    }
    void AddPickup()
    {
        numPickups++;
    }
}


