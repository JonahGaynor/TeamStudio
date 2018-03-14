using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlScript : MonoBehaviour {

	public float myOffset;
    public LoveMovement moveScript;
    GameObject littleBoy;
    public float speed;
        float placeToGo;
	// Use this for initialization
	void Start () {
        littleBoy = GameObject.Find("Little Boy");
        moveScript = littleBoy.GetComponent<LoveMovement>();
        speed = SixLaneGameController.Instance.standardMoveSpeed;
        myOffset = 4f;
	}

    // Update is called once per frame
    void Update()
    {
        speed = SixLaneGameController.Instance.standardMoveSpeed;
        myOffset = 14-(SixLaneGameController.Instance.life*2);

        placeToGo = littleBoy.transform.position.x + myOffset;
        Vector3 temp = this.transform.position;

        if (this.transform.position.x < placeToGo)
        {
            temp.x += speed * 1.5f;
        }

        if (this.transform.position.x > placeToGo)
        {
            temp.x += speed * 0.50f;
        }




        // temp.x = player.transform.position.x - offset;
        this.transform.position = temp;









    }







      /*  transform.position = new Vector3 (GameObject.Find ("Little Boy").GetComponent<Transform> ().position.x + myOffset, transform.position.y, 0f);
        if (this.transform.position.x< GameObject.Find("Little Boy").GetComponent<Transform>().position.x + myOffset)
            if (SixLaneGameController.Instance.life == 3) {
			myOffset = 4f;
		} else if (SixLaneGameController.Instance.life == 2) {
			myOffset = 6f;
		} else if (SixLaneGameController.Instance.life == 1) {
			myOffset = 8f;
		} 
	}*/
}	
