using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGravityScript : MonoBehaviour {

    public float runSpeed = 0.2f;
    public Sprite jumpingSprite;
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
    public bool canFlip=false;
    public bool flipOverride = true;
    public bool onGround = true;
    public bool hitTheGround = false;
    public bool onCeiling = false;
    //public int life = 5;

    bool hasFixed = false;
    public GameObject choiceScript;
    public GameObject obsGenerator;
    public float gravity, staticGravity;
    public AudioClip getHit;
    AudioSource myAudio;
    bool inCoroutine = false;
    int speedOverride = 1;

    public SpriteRenderer myRenderer;
    Animator myAnimator;
    public bool gravityOverride = false;
    public bool canGetHit;
	public bool letsFlip = false;
    public bool readyToMoveOn = false;
    // Use this for initialization
    void Start()
    {
        myAnimator = this.GetComponent<Animator>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myAudio = this.GetComponent<AudioSource>();
        myRigidbody = this.GetComponent<Rigidbody2D>();
        mySprite = this.GetComponent<SpriteRenderer>();
        myCollider = this.GetComponent<BoxCollider2D>();
      
        staticGravity = myRigidbody.gravityScale;
        gravity = staticGravity;
        canFloat = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("Blocker").GetComponent<SpriteRenderer>().material.color.a >= 0.9f)
        {
            ProofGameController.Instance.moveToNextLevel = true;
        }
        if (!ProofGameController.Instance.gameOver)
        {

            //mySprite.flipX = false;
            runSpeed = ProofGameController.Instance.standardMoveSpeed;
            //            Debug.Log(runSpeed);
            Vector3 temp = this.transform.position;
            temp.x += (runSpeed * speedOverride)*Time.timeScale;
            this.transform.position = temp;

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && canFlip&&!flipOverride)
            {
               
                myAnimator.SetTrigger("JumpUp");
                myAnimator.SetBool("ShouldRun", false);
                myRigidbody.gravityScale *= -1;
                canFlip = false;
            }
        }
        if (letsFlip)
        {
            SwapGravity();
           
        }
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.zero);
        if (onGround&&hitTheGround)
        {
             hit = Physics2D.Raycast(this.transform.position, this.transform.position+Vector3.up);
            Debug.DrawLine(this.transform.position, this.transform.position + Vector3.up, Color.red);
        }
        else if (onCeiling&&hitTheGround)
        {
             hit = Physics2D.Raycast(this.transform.position, this.transform.position- Vector3.up);
            Debug.DrawLine(this.transform.position, this.transform.position - Vector3.up, Color.red);

        }
        if (hit.collider != null)
        {
            if (hit.transform.tag=="Floor" && !canFlip)
            {
                hitTheGround = false;
                myAnimator.SetBool("FallJump", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Floor" && myRigidbody.velocity.y <= 0)
        {
            myAnimator.SetBool("FallJump", false);
            myAnimator.SetBool("ShouldRun", true);
            canFlip = true;

        }
        if (collision.gameObject.tag == "Platform")
        {
            myAnimator.SetBool("ShouldRun", true);
            canFlip = true;

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

        if (collider.tag == "Flipper")
        {
            hitTheGround = true;

            if (myRigidbody.velocity.y < 0)
            {
                //   Debug.Log("Should Flip");
                
                
                    myRenderer.flipY = false;
                    canFlip = false;
                
            }
            if (myRigidbody.velocity.y > 0)
            {
               
                    myRenderer.flipY = true;
                    canFlip = false;
                
            }


                if (onGround)
                {
                    onGround = false;
                    onCeiling = true;
                }
                else if (onCeiling)
                {
                    onCeiling = false;
                    onGround = true;
                }

            
        }

        if (collider.gameObject.tag == "Furniture" && ProofGameController.Instance.life > 0 && inCoroutine == false && canGetHit)
        {
            ProofGameController.Instance.life--;
            inCoroutine = true;
            jumpOverride = true;
            canFloat = false;
            MakeBoxSmall();
            // StartCoroutine(TakeDamage());
            myAnimator.SetTrigger("Death");
            StartCoroutine(ReadyToDie());
            speedOverride = 0;

            ProofGameController.Instance.fadeToEnd = true;
        }


        if (collider.tag == "Text")
        {
            readyToMoveOn = true;
            //ProofGameController.Instance.fadeToEnd = true;
            speedOverride = 0;
            mySprite.sprite = playerSprites[1];
            //mySprite.flipX = true;
            jumpOverride = true;
            canFloat = false;
            MakeBoxSmall();
            myAnimator.SetTrigger("Death");
            //			StartCoroutine (ReadyToDie ());
            // myAnimator.SetBool("ShouldRun", false);


        }
       
        if (collider.gameObject.tag == "AllowGenerator")
        {
            flipOverride = false;
            this.transform.GetChild(0).GetComponent<GenericSectionSpawner>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Flipper")
        {
            hitTheGround = true;

            if (myRigidbody.velocity.y < 0)
            {
                //   Debug.Log("Should Flip");


                myRenderer.flipY = false;
                canFlip = false;

            }
            if (myRigidbody.velocity.y > 0)
            {

                myRenderer.flipY = true;
                canFlip = false;

            }
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

    IEnumerator ReadyToDie()
    {
        yield return new WaitForSeconds(1.5f);
        //		GetComponent<CameraControl> ().fadeToWhite = true;
        yield return new WaitForSeconds(1.5f);

        ProofGameController.Instance.gameOver = true;

    }


    void MakeBoxSmall()
    {
        // myCollider.size =new Vector2(4.88f, 2.5f);
        //myCollider.offset = new Vector2(0, -1.25f);
    }
    void SwapGravity()
    {
		letsFlip = false;
        myRigidbody.gravityScale *= -1;
    }

}
