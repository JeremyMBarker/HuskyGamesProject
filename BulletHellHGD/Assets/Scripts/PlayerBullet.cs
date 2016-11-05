using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{

    private float bSpeed;
        //Speed of the bullet
    private Rigidbody2D rb2d;
        //The rigid body of the bullet.

    void Start()
    {
        //Set the bullets velocity forward * the speed of the bullet. First ensure that 
        //The rigidbody isn't null. 

        bSpeed = gameObject.GetComponent<BulletInfo>().bulletSpeed;
            //Grabbing the bullet speed from BulletInfo script.
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.velocity = (transform.up * bSpeed);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
