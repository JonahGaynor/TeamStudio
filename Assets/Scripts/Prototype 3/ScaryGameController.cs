using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryGameController : MonoBehaviour {



    public static ScaryGameController Instance = new ScaryGameController();
    public int life = 10;
    int prevPickups;
    public int numPickups=0;
    public float standardMoveSpeed = 0.175f;
    public bool gameOver = false;
    public float timeToWait = 2;
    public GameObject player;
   // CharacterControlSixLane charScript;

    // Use this for initialization
    void Start()
    {
           life = 10;
        prevPickups = numPickups;
    Instance = this;
        standardMoveSpeed = 0.1f;
        // standardMoveSpeed = 5;
       // charScript = player.GetComponent<CharacterControlSixLane>();
    }

    // Update is called once per frame
    void Update()
    {
      //  charScript.runSpeed = standardMoveSpeed;
        if (prevPickups != numPickups)
        {
            life++;
                prevPickups = numPickups;
        }
      
      
        
      
    }
    void AddPickup()
    {
        numPickups++;
    }
}


