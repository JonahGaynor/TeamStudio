using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashScript : MonoBehaviour {
    Rigidbody2D myRigidbody;
    public float dashLength = 0.5f;
    TestJump myJumpScript;
    float beforeGravity;
    public bool dashing = false;
    CameraControl myCameraScript;
    float cameraOffset;
    float OGCameraOffset;
    float cameraOffestTimer=0.25f;
    float t = 0;
    public float dashCooldown = 2f;
    bool canDash=true;
    public GameObject dashImageSprite;
    public Color dashImage;
     Animator myAnimator;
    BoxCollider2D myCollider;
	//public float timeSinceLevelBegan = 0f;
	//public float timeForLevel = 10f;
	// Use this for initialization
	void Start () {
        myCollider = this.gameObject.GetComponent<BoxCollider2D>();
        ResetCollider();
        myAnimator = this.gameObject.GetComponent<Animator>();
        dashImage = dashImageSprite.GetComponent<Image>().color;
        myRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        myJumpScript = this.gameObject.GetComponent<TestJump>();
        myCameraScript = GameObject.Find("Main Camera").GetComponent<CameraControl>();
        OGCameraOffset = myCameraScript.offset;
        cameraOffset = OGCameraOffset;
        
	}
	void Update () {
		/*timeSinceLevelBegan += Time.deltaTime;
        //Debug.Log(myAnimator.GetBool("ShouldRun"));
		if (timeSinceLevelBegan >= timeForLevel) {
			ProofGameController.Instance.moveToNextLevel = true;
		}*/
        if (!dashing) {
            
            myJumpScript.gravityOverride = false;
            cameraOffestTimer -= Time.deltaTime;

            if (cameraOffestTimer<0)
            {
                ResetCollider();
                myAnimator.SetBool("HasDashed", false);
                myCameraScript.offset = cameraOffset;
                myRigidbody.drag = 0;
                cameraOffset = Mathf.Lerp(cameraOffset, OGCameraOffset, t);
                t += 0.1f * Time.deltaTime;
            }
        }
        if (dashing)
        {
            myAnimator.SetBool("HasDashed", true);
            //myAnimator.SetBool("ShouldRun", false);
            cameraOffestTimer = 0.25f;
            myCameraScript.offset = cameraOffset;
            cameraOffset = Mathf.Lerp(cameraOffset, -OGCameraOffset/100,  0.08f);
//            t += 0.1f * Time.deltaTime;
            dashLength -= Time.deltaTime;
            if (dashLength < 0)
            {
                t = 0;
                dashing = false;
                dashLength = 0.5f;
            }
        }
		if((Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow))&&canDash)
        {
            SetDashCollider();
           // myAnimator.SetBool("ShouldRun", false);
            canDash = false;
            dashCooldown = 2f;
            myRigidbody.drag = 6;
            beforeGravity = myRigidbody.gravityScale;
            dashing = true;
            myRigidbody.gravityScale = 0;
            myJumpScript.gravityOverride = true;
            float XVel = myRigidbody.velocity.x;
            myRigidbody.velocity = new Vector2(XVel, 0);
            myRigidbody.AddForce(new Vector2(750, 0));
        }
        if (!canDash)
        {
            Color tempColor = dashImage;
            tempColor.a = 0;
            dashImage = tempColor;
            dashImageSprite.GetComponent<Image>().color = dashImage;
            dashCooldown -= Time.deltaTime;
            dashImageSprite.transform.GetChild(0).gameObject.SetActive(false);
            if (dashCooldown < 0)
            {
               
                dashCooldown = 2f;
                canDash = true;
            }
        }
        if (canDash)
        {
            Color temporary = dashImage;
            temporary.a = 255;
            dashImage = temporary;
            dashImageSprite.transform.GetChild(0).gameObject.SetActive(true);
            dashImageSprite.GetComponent<Image>().color = dashImage;
        }

	}
    public void SetDashCollider()
    {
        Vector2 temp = myCollider.size;
        temp.x = 4.962863f;
        temp.y = 3.264728f;
        myCollider.size = temp;
        temp = myCollider.offset;
        temp.x = -0.05196369f;
        temp.y = 0.6172091f;
        myCollider.offset = temp;
        return;
    }

    public void ResetCollider()
    {
        Vector2 temp = myCollider.size;
        temp.x = 4.339115f;
        temp.y = 5.834111f;
        myCollider.size = temp;
        temp = myCollider.offset;
        temp.x = -0.3638377f;
        temp.y = 0.07755256f;
        myCollider.offset = temp;
        return;
    }
}
