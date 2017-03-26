using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeed : MonoBehaviour {
    public float speedMod; // How much we will multiply current move speed by.
    public float powerUpDuration;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check for player.
        if (other.gameObject.tag == "Player")
        {

            if (other.gameObject.GetComponent<PlayerControl>().poweredUpSpeed == true)
            {
                //If the player has the power-up, just extend it's timer.
                other.gameObject.GetComponent<PlayerControl>().powerUpEndSpeed = (Time.time + powerUpDuration);
                Destroy(this.gameObject);
                return;
            }

            float curSpeed = other.gameObject.GetComponent<PlayerControl>().playerSpeed;
            float newSpeed = curSpeed * speedMod;
            other.gameObject.GetComponent<PlayerControl>().playerSpeed = newSpeed;
            other.gameObject.GetComponent<PlayerControl>().powerUpEndSpeed = (Time.time + powerUpDuration);
            other.gameObject.GetComponent<PlayerControl>().poweredUpSpeed = true;
            Destroy(this.gameObject);

        }
    }
}
