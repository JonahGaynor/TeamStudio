using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomMovementScript : MonoBehaviour {

    //intended features:
    // 1. mom jumps every so often
     int jump = 200;
	public float jumpTimer = 0;
	public bool didLand = false;
	public Rigidbody2D rb;
    public bool hasJumped = false;
    public Sprite funeralSprite;
    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (jumpTimer >= 4f&&!GameController.Instance.gameOver) {
            Vector2 jumpForce = new Vector2(0f, 5f);

            rb.AddForce(transform.up * jump);
            hasJumped = true;
            jumpTimer = 0f;
		}
        if (GameController.Instance.hitText&& !GameController.Instance.atFuneral)
        {
            SpriteRenderer momSprite = this.GetComponent<SpriteRenderer>();
            BoxCollider2D momCollider = this.GetComponent<BoxCollider2D>();
          //  momCollider.enabled = false;
            momSprite.enabled = false;
        }
        else if(GameController.Instance.hitText&& GameController.Instance.atFuneral)
        {
            SpriteRenderer momSprite = this.GetComponent<SpriteRenderer>();
            BoxCollider2D momCollider = this.GetComponent<BoxCollider2D>();
           // momCollider.enabled = true;
            momSprite.enabled = true;
            momSprite.sprite = funeralSprite;
        }
        else
        {
            jumpTimer += Time.deltaTime;
        }
	}


	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Floor"&&hasJumped) {
			didLand = true;
            hasJumped = false;
			StartCoroutine (landCoroutine(1f));
		}

	}

	IEnumerator landCoroutine(float shakeTime){
		yield return new WaitForSeconds (.3f);
		didLand = false;
	}

}
