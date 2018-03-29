using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour {

	public GameObject brokenWall;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.K)){
			die ();
		}

        if (GameObject.Find("Little Boy").GetComponent<DashScript>().dashing)
        {
            this.tag = "Untagged";
        }
        if (!GameObject.Find("Little Boy").GetComponent<DashScript>().dashing)
        {
            this.tag = "Furniture";
        }

    }

   

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Little Boy" && col.transform.gameObject.GetComponent<DashScript>().dashing) {
			die ();
		}
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }

    public void die (){
		Vector2 wallPos1 = new Vector2 (transform.position.x, transform.position.y + 1.5f);
		Vector2 wallPos2 = new Vector2 (transform.position.x, transform.position.y + 0.5f);
		Vector2 wallPos3 = new Vector2 (transform.position.x, transform.position.y - 0.5f);
		Vector2 wallPos4 = new Vector2 (transform.position.x, transform.position.y - 1.5f);

		GameObject wall1 = Instantiate (brokenWall, wallPos1, Quaternion.identity);
		GameObject wall2 = Instantiate (brokenWall, wallPos2, Quaternion.identity);
		GameObject wall3 = Instantiate (brokenWall, wallPos3, Quaternion.identity);
		GameObject wall4 = Instantiate (brokenWall, wallPos4, Quaternion.identity);

		wall1.transform.name = "wall1";
		wall2.transform.name = "wall2";
		wall3.transform.name = "wall3";
		wall4.transform.name = "wall4";

		Destroy (this.gameObject);
	}
}
