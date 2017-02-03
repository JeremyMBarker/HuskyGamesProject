using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeed : MonoBehaviour {
    public float speedMod; // How much we will multiply current move speed by.


    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check for player.
        if (other.gameObject.tag == "Player")
        {
            float curSpeed = other.gameObject.GetComponent<PlayerMovement>().playerSpeed;
            float newSpeed = curSpeed * speedMod;
            other.gameObject.GetComponent<PlayerMovement>().playerSpeed = newSpeed;
            Destroy(this.gameObject);

        }
    }
}
