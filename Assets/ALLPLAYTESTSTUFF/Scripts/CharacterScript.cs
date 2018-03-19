
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour {
     float runSpeed = 0.2f;
    public float jump =10f;
    public Rigidbody2D myRigidbody;
    public Sprite[] playerSprites;
    public SpriteRenderer mySprite;
    public BoxCollider2D myCollider;
  //  public bool gameOver = false;
    public bool canJump = true;
    public bool canGetUp = true;
    public bool jumpOverride = false;
    //public int life = 5;
    public Text lifeText;
    bool hasFixed = false;
    public GameObject choiceScript;
    public GameObject obsGenerator;
	public AudioClip getHit;
	AudioSource myAudio;
    
	// Use this for initialization
    void Start () {
		myAudio = GetComponent<AudioSource> ();
        myRigidbody = this.GetComponent<Rigidbody2D>();
        mySprite = this.GetComponent<SpriteRenderer>();
        myCollider = this.GetComponent<BoxCollider2D>();
        mySprite.sprite = playerSprites[0];
	}
	
	// Update is called once per frame
	void Update () {

        if (GameController.Instance.life == 0)
        {
           GameController.Instance.gameOver = true;
            mySprite.sprite = playerSprites[2];
        }
       lifeText.text = "" + GameController.Instance.life;
        if (!GameController.Instance.gameOver&&(!GameController.Instance.hitText||GameController.Instance.escapeTime))
        {
            
            mySprite.flipX = false;
            runSpeed =GameController.Instance.standardMoveSpeed;
            Vector3 temp = this.transform.position;
            temp.x += runSpeed;
            this.transform.position = temp;
            if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (canJump)
                {
                    if (!jumpOverride)
                    {
                        canJump = false;
                        FixOneTime();
                        myRigidbody.AddForce(transform.up * jump);
                        
                    }
                }

            }
            if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && canJump)
            {
                mySprite.sprite = playerSprites[1];
                Vector2 newOffset = new Vector2(0, -0.8f);
                myCollider.offset = newOffset;
                Vector2 newSize = new Vector2(4.88f, 2f);
                myCollider.size = newSize;
            }
             if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)))
            {
                if (canGetUp)
                {
                    mySprite.sprite = playerSprites[0];
                    Vector2 newOffset = new Vector2(0, 0f);
                    myCollider.offset = newOffset;
                    Vector2 newSize = new Vector2(4.88f, 5f);
                    myCollider.size = newSize;
                }
            }
            if (!hasFixed&&GameController.Instance.escapeTime)
            {
                hasFixed = FixOneTime();
            }
            if (GameController.Instance.atFuneral)
            {
                mySprite.sprite = playerSprites[4];
            }
           // if (this.transform.position.x >= 877)
           // {
           //     GameController.Instance.standardMoveSpeed = 0f;
          //  }


        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            canJump = true;
            if (Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow))
            {
                mySprite.sprite = playerSprites[1];
                Vector2 newOffset = new Vector2(0, -0.8f);
                myCollider.offset = newOffset;
                Vector2 newSize = new Vector2(4.88f, 2f);
                myCollider.size = newSize;
            }
        }
        if (collision.gameObject.tag == "Text")
        {
            runSpeed = 0;
            mySprite.sprite = playerSprites[3];
            Vector2 newOffset = new Vector2(0, -0.1f);
            myCollider.offset = newOffset;
            Vector2 newSize = new Vector2(4.88f, 2f);
            myCollider.size = newSize;
            mySprite.flipX = true;
            GameController.Instance.hitText = true;
        }
        if (collision.gameObject.tag == "Bricks")
        {
            GameController.Instance.gameOver = true;
            DeathByBricks();

        }

       
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Furniture" && GameController.Instance.life>0)
        {
           GameController.Instance.life--;
			StartCoroutine (TakeDamage ());
        }
        if (collider.gameObject.tag == "Funeral")
        {
            GameController.Instance.atFuneral = true;
        }
        if (collider.gameObject.tag == "ChoiceSection")
        {
            if (Input.GetKey(KeyCode.S))
            {
                jumpOverride = true;
                canGetUp = false;
            }
            ChoiceChoicesScript.Instance.atChoice = true;
        }
        if (collider.gameObject.tag == "ChoiceThreshold")
        {
            ChoiceChoicesScript.Instance.withinThreshold = true;
        }
        if (collider.gameObject.tag == "TopChoice"&&GameController.Instance.questionsAnswered==3)
        {
            GameController.Instance.topChoiceMade = true;
        }
        if (collider.gameObject.tag == "BottomChoice" && GameController.Instance.questionsAnswered == 3)
        {
            GameController.Instance.bottomChoiceMade = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ChoiceSection")
        {
            jumpOverride = false;
            canGetUp = true;
            GetUpOneTime();
            GameController.Instance.questionsAnswered++;
            GameController.Instance.stopSpawning = false;
            GameController.Instance.startQuestion = false;
            LevelGenerationScript levelGen =choiceScript.GetComponent<LevelGenerationScript>();
            levelGen.hasSpawned = false;
            GeneratorScript generator = obsGenerator.GetComponent<GeneratorScript>();
            generator.stopSpawning = false;
        }   
    }
    bool FixOneTime()
    {
        mySprite.sprite = playerSprites[0];
        Vector2 newOffset = new Vector2(0, 0f);
        myCollider.offset = newOffset;
        Vector2 newSize = new Vector2(4.88f, 5f);
        myCollider.size = newSize;
        return true;
    }
    void DeathByBricks()
    {
        runSpeed = 0;
        mySprite.sprite = playerSprites[3];
        Vector2 newOffset = new Vector2(0, -0.1f);
        myCollider.offset = newOffset;
        Vector2 newSize = new Vector2(4.88f, 2f);
        myCollider.size = newSize;
    }
    void GetUpOneTime()
    {
        mySprite.sprite = playerSprites[0];
        Vector2 newOffset = new Vector2(0, 0f);
        myCollider.offset = newOffset;
        Vector2 newSize = new Vector2(4.88f, 5f);
        myCollider.size = newSize;
    }
	IEnumerator TakeDamage (){
		myAudio.Play();
		mySprite.enabled = false;
		yield return new WaitForSeconds (0.5f);
		mySprite.enabled = true;
		yield return new WaitForSeconds (0.5f);
		mySprite.enabled = false;
		yield return new WaitForSeconds (0.5f);
		mySprite.enabled = true;
	}

}
