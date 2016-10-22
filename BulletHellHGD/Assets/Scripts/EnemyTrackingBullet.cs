using UnityEngine;
using System.Collections;

public class EnemyTrackingBullet : MonoBehaviour
{
 
    private bool stopTrack = false;
    public float bSpeed;
    private Rigidbody2D rb2d;
    private Vector2 initVeloc;

    void Start()
    {
        var pos = GameObject.Find("Player").transform.position;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.velocity = (pos - transform.position).normalized * bSpeed;
            initVeloc = rb2d.velocity;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTrack)
        {
            rb2d.velocity = initVeloc;
        }
        else
        {
            var pos = GameObject.Find("Player").transform.position;
   

            if(transform.position.y <= pos.y)
            {
                stopTrack = true;
            }
            else { }
            rb2d = gameObject.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.velocity = (pos - transform.position).normalized * bSpeed;

            }
        }
    
    }

}
   
