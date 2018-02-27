using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMaskScript : MonoBehaviour {
    public GameObject player;
    GameObject mouseObject;
    GameObject raycastObject;
    public bool atMouse = false;
    public Sprite circle;
    int direction = 1;
    float distance;
    float speed;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    // Use this for initialization
    void Start () {
        mouseObject = new GameObject("Mouse Position");
        SpriteRenderer visMouse=mouseObject.AddComponent<SpriteRenderer>();
        visMouse.sortingOrder = 2000;
        visMouse.sprite = circle;
        CircleCollider2D mouseCollider = mouseObject.AddComponent<CircleCollider2D>();
	}

    // Update is called once per frame
    void Update () {
        mouseObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {    
        if (raycastObject != null){Destroy(raycastObject.gameObject);}
        RaycastHit2D hit = Physics2D.Raycast(this.transform.parent.position, transform.right, mouseObject.transform.position.x-this.transform.parent.position.x);
        raycastObject = new GameObject("End Of Raycast");
        Vector3 temp2pos = this.transform.parent.position + (transform.right * (mouseObject.transform.position.x - this.transform.parent.position.x));
        raycastObject.transform.position = temp2pos;
        SpriteRenderer raycastSprite = raycastObject.AddComponent<SpriteRenderer>();
        raycastSprite.sortingOrder = 2000;
        if (raycastObject.transform.position.y > mouseObject.transform.position.y){direction = -1;}
        if (raycastObject.transform.position.y < mouseObject.transform.position.y){direction = 1;}
        distance = Mathf.Abs(raycastObject.transform.position.y - mouseObject.transform.position.y);
        speed = distance/5;
       // Debug.DrawLine(this.transform.parent.position, transform.right* (mouseObject.transform.position.x - this.transform.parent.position.x));
       
            transform.RotateAround(this.transform.parent.position, zAxis, speed*direction);
        
    }

}
