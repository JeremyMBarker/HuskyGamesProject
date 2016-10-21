using UnityEngine;
using System.Collections;

public class EnemyBasicBullet : MonoBehaviour {

    public float bSpeed;
    private Rigidbody2D rb2d;

    void Start()
    {
        var pos = GameObject.Find("Player").transform.position;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.velocity = (pos - transform.position).normalized * bSpeed;

        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
