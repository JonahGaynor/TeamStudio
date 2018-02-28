using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag=="Little Boy")
        {
            GameObject controller = GameObject.Find("GameController");
            controller.SendMessage("AddPickup");
          //  ScaryGameController.Instance.numPickups++;
            Destroy(this.gameObject);
        }


    }
}
