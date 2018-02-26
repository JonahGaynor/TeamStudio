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
	// Use this for initialization
	void Start () {
      //  Debug.DrawLine(this.transform.parent.position, transform.right * 10000, Color.red, 100000,false);
        mouseObject = new GameObject("Mouse Position");
        SpriteRenderer visMouse=mouseObject.AddComponent<SpriteRenderer>();
        visMouse.sortingOrder = 2000;
        visMouse.sprite = circle;
        CircleCollider2D mouseCollider = mouseObject.AddComponent<CircleCollider2D>();
       // Instantiate(mouseObject);
	}
    public Transform target;
    float angle;
    private Vector3 zAxis = new Vector3(0, 0, 1);

   
    // Update is called once per frame
    void Update () {
        mouseObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      
           //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
         angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

    }
    void FixedUpdate()
    {
       
        Debug.Log(atMouse);
        if (raycastObject != null)
        {
            Destroy(raycastObject.gameObject);
        }
        RaycastHit2D hit = Physics2D.Raycast(this.transform.parent.position, transform.right, mouseObject.transform.position.x-this.transform.parent.position.x);
         raycastObject = new GameObject("End Of Raycast");
        Vector3 temp2pos = this.transform.parent.position + (transform.right * (mouseObject.transform.position.x - this.transform.parent.position.x));

        raycastObject.transform.position = temp2pos;
         SpriteRenderer raycastSprite = raycastObject.AddComponent<SpriteRenderer>();
        raycastSprite.sortingOrder = 2000;
        if (raycastObject.transform.position.y > mouseObject.transform.position.y)
        {
           
            direction = -1;
        }
        if (raycastObject.transform.position.y < mouseObject.transform.position.y)
        {
            direction = 1;
        }
        distance = Mathf.Abs(raycastObject.transform.position.y - mouseObject.transform.position.y);
        Debug.Log("Distance: " + distance);
        speed = distance/5;
        Debug.Log("Speed: "+speed);
        Debug.DrawLine(this.transform.parent.position, transform.right* (mouseObject.transform.position.x - this.transform.parent.position.x));
       
            transform.RotateAround(target.position, zAxis, speed*direction);
        
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
