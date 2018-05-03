
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeLifeJumpScript : MonoBehaviour
{
    //longest jump: 7.2
    //shortest jump: 4.8
    //middle jump: 6


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
    public SpriteRenderer myRenderer;
    Animator myAnimator;
    public bool gravityOverride = false;
    public bool canGetHit;
    public bool readyToMoveOn = false;
    // Use this for initialization
    void Start()
    {
        myAnimator = this.GetComponent<Animator>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myAudio = GetComponent<AudioSource>();
        myRigidbody = this.GetComponent<Rigidbody2D>();
        mySprite = this.GetComponent<SpriteRenderer>();
        myCollider = this.GetComponent<BoxCollider2D>();
       // mySprite.sprite = playerSprites[0];
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
        if (!gravityOverride)
        {
            myRigidbody.gravityScale = gravity;
        }
        if (!ProofGameController.Instance.gameOver)
        {

            runSpeed = ProofGameController.Instance.standardMoveSpeed;
            Vector3 temp = this.transform.position;
            temp.x += (runSpeed * speedOverride * Time.timeScale);
            this.transform.position = temp;
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                if (keyDownCounter <= 0.1f)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y / 2);
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
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (transform.position.y <= -3.7f && transform.position.y >= -3.83f)
                {
                    jumpOnHit = false;
                }
                if (canJump && !jumpOverride)
                {
                    canFloat = true;
                    myRigidbody.velocity = Vector2.zero;
                    canJump = false;
                    myAnimator.SetBool("ShouldRun", false);
                    myAnimator.SetTrigger("JumpUp");
                    if (HomeLifeManager.Instance.stressLevel > 1)
                    {
                        myRigidbody.AddForce((transform.up * jump) *( 1+((1-HomeLifeManager.Instance.stressLevel))/50));
                        
                    }
                    else
                    {
                        myRigidbody.AddForce((transform.up * jump) );
                    }
                }
            }
            if (readyToMoveOn)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    ProofGameController.Instance.fadeToEnd = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (myRigidbody.velocity.y < -1f && !canJump)
        {
            myAnimator.SetBool("FallJump", true);
            gravity = 4;
            dropCounter += Time.deltaTime;
        }
        if (myRigidbody.velocity.y < -8f && !canJump)
        {
            gravity = 8;

        }
        if (myRigidbody.velocity.y < -10f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -10f);
        }
        if (dropCounter >= 0.3f)
        {
            gravity = 8.2f;
        }
        if (dropCounter >= 0.4f)
        {
            gravity = 8.3f;
        }
        if (dropCounter >= 0.5f)
        {
            gravity = 8.4f;
        }
        if (dropCounter >= 0.6f)
        {
            gravity = 8.5f;
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

        if (collision.gameObject.tag == "Floor" && myRigidbody.velocity.y <= 0)
        {
            myAnimator.SetBool("FallJump", false);
            myAnimator.SetBool("ShouldRun", true);
            dropCounter = 0f;
            gravity = staticGravity;
            canJump = true;
            floatTime = 0;
            canFloat = false;

        }
        if (collision.gameObject.tag == "Platform")
        {
            myAnimator.SetBool("ShouldRun", true);
            dropCounter = 0f;
            if (this.transform.position.y > collision.transform.position.y)
            {
                gravity = staticGravity;
                canJump = true;
                floatTime = 0;
                canFloat = false;
            }
        }
        if (jumpOnHit && collision.gameObject.tag == "Floor")
        {
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
        if (collider.gameObject.tag == "Furniture" && ProofGameController.Instance.life > 0 && inCoroutine == false && canGetHit)
        {
            ProofGameController.Instance.life--;
            inCoroutine = true;
            jumpOverride = true;
            canFloat = false;
            MakeBoxSmall();
            myAnimator.SetTrigger("Death");
            StartCoroutine(ReadyToDie());
            speedOverride = 0;
            ProofGameController.Instance.fadeToEnd = true;
        }


        if (collider.tag == "Text")
        {
            readyToMoveOn = true;
            speedOverride = 0;
            mySprite.sprite = playerSprites[1]; ;
            jumpOverride = true;
            canFloat = false;
            MakeBoxSmall();
            myAnimator.SetTrigger("Death");
        }
       

    }

    

    public IEnumerator TakeDamage()
    {
        myAudio.Play();
        mySprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        mySprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        mySprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        mySprite.enabled = true;
        inCoroutine = false;
    }

    IEnumerator ReadyToDie()
    {
        yield return new WaitForSeconds(1.5f);
        yield return new WaitForSeconds(1.5f);
        ProofGameController.Instance.gameOver = true;
    }

    public void MakeBoxSmall()
    {

    }
}

