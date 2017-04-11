using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
    public float powerUpDuration;
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check for player.
        if (other.gameObject.tag == "Player")
        {

            if (other.gameObject.GetComponent<PlayerControl>().poweredUpShield == true)
            {
                //If the player has the power-up, just extend it's timer.
                other.gameObject.GetComponent<PlayerControl>().powerUpEndShield = (Time.time + powerUpDuration);
                Destroy(this.gameObject);
                return;
            }
			other.gameObject.GetComponent<PlayerControl>().poweredUpShield = true;
			other.gameObject.GetComponent<PlayerControl>().shield_item.GetComponent<SpriteRenderer> ().enabled = true;
            other.gameObject.GetComponent<PlayerControl>().powerUpEndShield = (Time.time + powerUpDuration);
            other.gameObject.GetComponent<PlayerControl>().poweredUpShield = true;
            Destroy(this.gameObject);

        }
    }
}
