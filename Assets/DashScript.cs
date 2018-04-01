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
	// Use this for initialization
	void Start () {
        dashImage = dashImageSprite.GetComponent<SpriteRenderer>().color;
        myRigidbody = this.GetComponent<Rigidbody2D>();
        myJumpScript = this.GetComponent<TestJump>();
        myCameraScript = GameObject.Find("Main Camera").GetComponent<CameraControl>();
        OGCameraOffset = myCameraScript.offset;
        cameraOffset = OGCameraOffset;
	}
	void Update () {
        if (!dashing) {
                myJumpScript.gravityOverride = false;
            cameraOffestTimer -= Time.deltaTime;

            if (cameraOffestTimer<0)
            {
                myCameraScript.offset = cameraOffset;
                myRigidbody.drag = 0;
                cameraOffset = Mathf.Lerp(cameraOffset, OGCameraOffset, t);
                t += 0.1f * Time.deltaTime;
            }
        }
        if (dashing)
        {
            cameraOffestTimer = 0.25f;
            myCameraScript.offset = cameraOffset;
            cameraOffset = Mathf.Lerp(cameraOffset, -OGCameraOffset/2,  t);
            t += 0.1f * Time.deltaTime;
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
            dashImageSprite.GetComponent<SpriteRenderer>().color = dashImage;
            dashCooldown -= Time.deltaTime;
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
            dashImageSprite.GetComponent<SpriteRenderer>().color = dashImage;
        }
	}
}
