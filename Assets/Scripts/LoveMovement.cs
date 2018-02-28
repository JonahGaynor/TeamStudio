using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveMovement : MonoBehaviour {
    public float invincibilityTime = 3f;
	float jumpForce;
	public Rigidbody2D rb;
	public float runSpeed = 0.4f;
	public AudioClip getHit;
	AudioSource myAudio;
	bool inCoroutine = false;
	public SpriteRenderer mySprite;

	// Use this for initialization
	void Start () {
         invincibilityTime = 3f;
        rb = this.GetComponent<Rigidbody2D> ();
		jumpForce = 40f;
		myAudio = GetComponent<AudioSource> ();
		mySprite = this.GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
        invincibilityTime -= Time.deltaTime;
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			rb.AddForce (transform.up * jumpForce);
			jumpForce += 10f * Time.deltaTime;
		}
		if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.UpArrow)) {
			jumpForce = 40f;
		}
		runSpeed = SixLaneGameController.Instance.standardMoveSpeed;
		Vector3 temp = this.transform.position;
		temp.x += runSpeed;
		this.transform.position = temp;
	}
	private void OnTriggerEnter2D(Collider2D collider)
	{
        if (collider.gameObject.tag == "Furniture" && SixLaneGameController.Instance.life > 0 && inCoroutine == false)
        {
            if (invincibilityTime <= 0)
            {
                SixLaneGameController.Instance.life--;
                inCoroutine = true;
                StartCoroutine(TakeDamage());
            }
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

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Furniture" && SixLaneGameController.Instance.life > 0 && inCoroutine == false)
        {
            if (invincibilityTime <= 0)
            {
                SixLaneGameController.Instance.life--;
                inCoroutine = true;
                StartCoroutine(TakeDamage());
            }
        }
    }

        IEnumerator TakeDamage (){
		myAudio.Play();
		mySprite.enabled = false;
		yield return new WaitForSeconds (0.2f);
		mySprite.enabled = true;
		yield return new WaitForSeconds (0.2f);
		mySprite.enabled = false;
		yield return new WaitForSeconds (0.2f);
		mySprite.enabled = true;
		inCoroutine = false;
	}
}
