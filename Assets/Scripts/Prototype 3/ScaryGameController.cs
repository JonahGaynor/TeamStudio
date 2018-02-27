using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryGameController : MonoBehaviour {



    public static ScaryGameController Instance = new ScaryGameController();
    public int life = 10;
    public int numPickups;
    public float standardMoveSpeed = 0.175f;
    public bool gameOver = false;
    public float timeToWait = 2;
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
      
      
        
      
    }
}


