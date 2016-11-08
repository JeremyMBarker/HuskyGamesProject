using UnityEngine;
using System.Collections;

public class EnemyTrackingBullet : MonoBehaviour
{
    private bool stopTrack = false; 
        //If True, bullet will continue to track  players current position.
    private float bSpeed;
        //Speed of the tracking bullet.
    private Rigidbody2D rb2d;
    public float trackingTime;
    //How long the bullet should track the player. After the time it will continue in a straight path.
    public float trackDelay;
    //How long before tracking should begin.
    private float startTime;
    //Holds value of when tracking began.
    private float initTime;
    //Time when bullet is instantiated.
   
    void Start()
    {
        initTime = Time.time;
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
        bSpeed = gameObject.GetComponent<BulletInfo>().bulletSpeed;

        if (Time.time >= initTime + trackDelay)
        {


            //Get the bullet speed from it's BulletInfo script.
            if (GameObject.Find("Player") != null)
            {
                //If there is a player still, find it's position.
                var pos = GameObject.Find("Player").transform.position;
                if (rb2d != null)
                {
                    //Set the bulelts velocity in the direction of the player's position.
                    rb2d.velocity = (pos - transform.position).normalized * bSpeed;

                }
                //Get time when tracking started.
                startTime = Time.time;
            }
            else
            {
                if (rb2d != null)
                {
                    //If player is dead, simply shoot forward.
                    rb2d.velocity = transform.forward * -bSpeed;
                    startTime = Time.time;

                }
            }
        }
        else
        {
            rb2d.velocity = (transform.up * bSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= initTime + trackDelay)
        {
            //If We have no player, or tracking is over, let the bullet continue to forward.
            if (stopTrack || GameObject.Find("Player") == null)
            {


            }
            else
            {
                //Get the players current position
                var pos = GameObject.Find("Player").transform.position;

                //Check if tracking is still going.
                if (Time.time > (startTime + trackingTime))
                {
                    stopTrack = true;
                }
                else
                {
                    //Tracking is still going, set the bullets velocity towards the player's position.
                    rb2d = gameObject.GetComponent<Rigidbody2D>();
                    if (rb2d != null)
                    {

                        rb2d.velocity = (pos - transform.position).normalized * bSpeed;

                    }
                }
            }

        }
       else
        {
            rb2d.velocity = (transform.up * bSpeed);
        }
            
    }

}
   
