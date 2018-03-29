using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour {
    Rigidbody2D myRigidbody;
    public float dashLength = 0.5f;
    TestJump myJumpScript;
    float beforeGravity;
    bool dashing = false;
    CameraControl myCameraScript;
    float cameraOffset;
    float OGCameraOffset;
    float cameraOffestTimer=0.25f;
    float t = 0;
	// Use this for initialization
	void Start () {
        myRigidbody = this.GetComponent<Rigidbody2D>();
        myJumpScript = this.GetComponent<TestJump>();
        myCameraScript = GameObject.Find("Main Camera").GetComponent<CameraControl>();
        OGCameraOffset = myCameraScript.offset;
        cameraOffset = OGCameraOffset;
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(dashing);
        if (!dashing) {
            myJumpScript.gravityOverride = false;
            cameraOffestTimer -= Time.deltaTime;
            if (cameraOffestTimer<0)
            {
                myCameraScript.offset = cameraOffset;
                
                cameraOffset = Mathf.Lerp(cameraOffset, OGCameraOffset, t);
                t += 0.1f * Time.deltaTime;
            }
           
            //Debug.Log(cameraOffset);
        }
        if (dashing)
        {
            cameraOffestTimer = 0.25f;
            myCameraScript.offset = cameraOffset;
            cameraOffset = Mathf.Lerp(cameraOffset, -OGCameraOffset/2,  t);
            t += 0.1f * Time.deltaTime;
            Debug.Log(cameraOffset);
            dashLength -= Time.deltaTime;
            if (dashLength < 0)
            {
                t = 0;
                dashing = false;
                dashLength = 0.5f;
            }
        }
		if(Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow))
        {
            beforeGravity = myRigidbody.gravityScale;
            dashing = true;
            myRigidbody.gravityScale = 0;
            myJumpScript.gravityOverride = true;
            float XVel = myRigidbody.velocity.x;
            myRigidbody.velocity = new Vector2(XVel, 0);
            myRigidbody.AddForce(new Vector2(750, 0));


        }
	}
}
