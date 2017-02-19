using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpeed : MonoBehaviour {
    public float speedMod; // How much we will multiply current shot speed by.
   

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
       //Check for player.
       if(other.gameObject.tag == "Player")
        {
           other.gameObject.GetComponent<PlayerShoot>().fireRate = (other.gameObject.GetComponent<PlayerShoot>().fireRate / speedMod);
            Destroy(this.gameObject);

        }
    }
}
