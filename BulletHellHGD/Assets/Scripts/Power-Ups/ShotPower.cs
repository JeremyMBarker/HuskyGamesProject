using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPower : MonoBehaviour {

    public GameObject playerBullet;
    public float powerUpDuration;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            if(playerBullet.GetComponent<BulletInfo>().poweredUp == true)
            {
                playerBullet.GetComponent<BulletInfo>().bulletDamage = 1313;
                playerBullet.GetComponent<BulletInfo>().powerUpEnd = (Time.time + powerUpDuration);
                Destroy(this.gameObject);
                return;
            }


            playerBullet.GetComponent<BulletInfo>().powerUpEnd = (Time.time + powerUpDuration);
            playerBullet.GetComponent<BulletInfo>().poweredUp = true;
            playerBullet.GetComponent<BulletInfo>().bulletDamage = 1313;
            Destroy(this.gameObject);

        }
       



	}
}
