using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpeed : MonoBehaviour {
    public float speedMod; // How much we will multiply current shot speed by.
    public float powerUpDuration;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
       //Check for player.
       if(other.gameObject.tag == "Player")
        {

            if(other.gameObject.GetComponent<PlayerShoot>().poweredUp == true)
            {
                //If the player has the power-up, just extend it's timer.
                other.gameObject.GetComponent<PlayerShoot>().powerUpEnd = (Time.time + powerUpDuration);
                Destroy(this.gameObject);
                return;
            }
           other.gameObject.GetComponent<PlayerShoot>().fireRate = (other.gameObject.GetComponent<PlayerShoot>().fireRate / speedMod);
           other.gameObject.GetComponent<PlayerShoot>().powerUpEnd = Time.time + powerUpDuration;
            other.gameObject.GetComponent<PlayerShoot>().poweredUp = true;
            Destroy(this.gameObject);

        }
    }
}
