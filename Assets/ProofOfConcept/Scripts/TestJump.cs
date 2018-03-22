
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestJump : MonoBehaviour
{
	//longest jump: 7.2
	//shortest jump: 4.8
	//middle jump: 6


    public float runSpeed = 0.2f;
     float jump = 350f;
     float smallJump = 15f;
    bool canFloat;
    float floatTime = 0;
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
    public float gravity, staticGravity;
    public AudioClip getHit;
    AudioSource myAudio;
    bool inCoroutine = false;
    int speedOverride = 1;
	int hitCounter = 0;
	float dropCounter = 0f;
	bool jumpOnHit = false;
	float keyDownCounter = 0f;

    // Use this for initialization
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myRigidbody = this.GetComponent<Rigidbody2D>();
        mySprite = this.GetComponent<SpriteRenderer>();
        myCollider = this.GetComponent<BoxCollider2D>();
        mySprite.sprite = playerSprites[0];
        staticGravity = myRigidbody.gravityScale;
        gravity = staticGravity;
        canFloat = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(1.0f / Time.deltaTime);
        myRigidbody.gravityScale = gravity;
      
        // lifeText.text = "" + SixLaneGameController.Instance.life;
		if (!ProofGameController.Instance.gameOver)
        {

            //mySprite.flipX = false;
			runSpeed = ProofGameController.Instance.standardMoveSpeed;
            Vector3 temp = this.transform.position;
            temp.x += (runSpeed*speedOverride);
            this.transform.position = temp;
            //Debug.Log(canFloat);

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
				if (keyDownCounter <= 0.05f) {
					myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, myRigidbody.velocity.y/2);
				}
				keyDownCounter = 0f;
                canFloat = false;
				floatTime = 0;
            }

            if (floatTime > 14)
            {
                floatTime = 0;
                canFloat = false;
            }


           /* if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                gravity = staticGravity + 25f;


            }*/


        }
    }

	void FixedUpdate(){
		if (myRigidbody.velocity.y < -1f&&!canJump)
		{
			gravity = 4;
			dropCounter += Time.deltaTime;
		}
		if (myRigidbody.velocity.y < -8f && !canJump) {
			gravity = 8;
		}
		if (myRigidbody.velocity.y < -10f) {
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, -10f);
		}
		if (dropCounter >= 0.3f) {
			gravity = 8.2f;
		}
		if (dropCounter >= 0.4f) {
			gravity = 8.3f;
		}
		if (dropCounter >= 0.5f) {
			gravity = 8.4f;
		}
		if (dropCounter >= 0.6f) {
			gravity = 8.5f;
		}

		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{ 
			if (transform.position.y <= -3.7f && transform.position.y >= -3.83f) {
				jumpOnHit = true;
			}
			if (canJump&&!jumpOverride)
			{
				canFloat = true;
				// Debug.Log(myRigidbody.velocity);
				myRigidbody.velocity = Vector2.zero;
				canJump = false;

				myRigidbody.AddForce(transform.up * jump);


			}

		}
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			if (canFloat)
			{
				floatTime++;
				myRigidbody.AddForce(transform.up * smallJump);    
			}
			keyDownCounter += Time.deltaTime;
		}

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		dropCounter = 0f;
        if (collision.gameObject.tag == "Floor")
        {
            gravity = staticGravity;
            canJump = true;
            floatTime = 0;
            canFloat = false;

        }
        if (collision.gameObject.tag == "Platform")
        {
            if (this.transform.position.y > collision.transform.position.y)
            {
                gravity = staticGravity;
                canJump = true;
                floatTime = 0;
                canFloat = false;
            }
        }
		if (jumpOnHit && collision.gameObject.tag == "Floor") {
			myRigidbody.AddForce(transform.up * jump);
			jumpOnHit = false;
		}

    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {

            if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                BoxCollider2D platformCollider = collision.gameObject.GetComponent<BoxCollider2D>();
                platformCollider.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
		if (collider.gameObject.tag == "Furniture" && ProofGameController.Instance.life > 0 && inCoroutine == false)
        {
			ProofGameController.Instance.life--;
            inCoroutine = true;
            StartCoroutine(TakeDamage());
        }

        if (collider.tag == "Text")
        {
				speedOverride = 0;
				mySprite.sprite = playerSprites [1];
				mySprite.flipX = true;
				jumpOverride = true;
				canFloat = false;
				MakeBoxSmall ();

        }

		if (collider.gameObject.tag == "TopChoice" && ProofGameController.Instance.questionsAnswered == 3)
        {
            SixLaneGameController.Instance.topChoiceMade = true;
        }
        if (collider.gameObject.tag == "BottomChoice" && SixLaneGameController.Instance.questionsAnswered == 3)
        {
            SixLaneGameController.Instance.bottomChoiceMade = true;
        }
    }



    IEnumerator TakeDamage()
    {
        myAudio.Play();
        mySprite.enabled = false;
        yield return new WaitForSeconds(0.2f);
        mySprite.enabled = true;
        yield return new WaitForSeconds(0.2f);
        mySprite.enabled = false;
        yield return new WaitForSeconds(0.2f);
        mySprite.enabled = true;
        inCoroutine = false;
    }


    void MakeBoxSmall()
    {
        myCollider.size =new Vector2(4.88f, 2.5f);
        //myCollider.offset = new Vector2(0, -1.25f);
    }

}

