using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{

    // Use this for initialization
    public float bSpeed;
    private Rigidbody2D rb2d;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(transform.up * bSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
