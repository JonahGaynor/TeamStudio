
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControlSixLane : MonoBehaviour
{
    float runSpeed = 0.2f;
    public float jump = 10f;
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
    public float gravity,staticGravity;
	public AudioClip getHit;
	AudioSource myAudio;
	bool inCoroutine = false;

    // Use this for initialization
    void Start()
    {
		myAudio = GetComponent<AudioSource> ();
        myRigidbody = this.GetComponent<Rigidbody2D>();
        mySprite = this.GetComponent<SpriteRenderer>();
        myCollider = this.GetComponent<BoxCollider2D>();
        mySprite.sprite = playerSprites[0];
        staticGravity = myRigidbody.gravityScale;
        gravity = staticGravity;
    }

    // Update is called once per frame
    void Update()
    {
    
        myRigidbody.gravityScale = gravity;
        if (SixLaneGameController.Instance.life == 0)
        {
            SixLaneGameController.Instance.gameOver = true;
            mySprite.sprite = playerSprites[2];
        }
        lifeText.text = "" + SixLaneGameController.Instance.life;
        if (!SixLaneGameController.Instance.gameOver)
        {

            mySprite.flipX = false;
            runSpeed = SixLaneGameController.Instance.standardMoveSpeed;
            Vector3 temp = this.transform.position;
            temp.x += runSpeed;
            this.transform.position = temp;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (canJump)
                {
                    if (!jumpOverride)
                    {
                        
                            canJump = false;

                            myRigidbody.AddForce(transform.up * jump);
                        
                    }
                }

            }
            if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                gravity = staticGravity + 25f;


            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            gravity = staticGravity;
            canJump = true;
            
        }
        if (collision.gameObject.tag == "Platform")
        {
            if (this.transform.position.y>collision.transform.position.y)
            {
                gravity = staticGravity;
                canJump = true;
            }
        }


    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            
            if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                BoxCollider2D platformCollider = collision.gameObject.GetComponent<BoxCollider2D>();
                platformCollider.enabled=false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
		if (collider.gameObject.tag == "Furniture" && SixLaneGameController.Instance.life > 0 && inCoroutine == false)
        {
            SixLaneGameController.Instance.life--;
			inCoroutine = true;
			StartCoroutine (TakeDamage ());
        }
       
        
       
        if (collider.gameObject.tag == "TopChoice" && SixLaneGameController.Instance.questionsAnswered == 3)
        {
            SixLaneGameController.Instance.topChoiceMade = true;
        }
        if (collider.gameObject.tag == "BottomChoice" && SixLaneGameController.Instance.questionsAnswered == 3)
        {
            SixLaneGameController.Instance.bottomChoiceMade = true;
        }
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
		inCoroutine = false;
	}

}

