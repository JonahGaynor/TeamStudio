using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProofGameController : MonoBehaviour {

	public static ProofGameController Instance = new ProofGameController();
    public int life = 10;
    public float standardMoveSpeed = .18f;
    public bool gameOver = false;
    public float timeToWait = 2;
    public bool fadeToEnd = false;
    public float timeToEnd = 5;
    public bool moveToNextLevel = false;
    public int levelsPast = 0;
    public bool stopSpawning = false;
    public bool spawnFadePrefab = false;
	public bool weWon = false;
    public GameObject player;
    int prevPickups;
    public int numPickups = 0;
    AudioSource deathSound;
    // Use this for initialization
    private void Awake()
    {
		Time.timeScale = 1.0f;
        moveToNextLevel = false;
    }
    void Start()
    {
        moveToNextLevel = false;
        deathSound = this.GetComponent<AudioSource>();
        life = 3;
   		Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0)
        {
            gameOver = true;
        }
		if (moveToNextLevel) {
			life = 50;
		}
    }
    void AddPickup()
    {
        numPickups++;
    }
}


