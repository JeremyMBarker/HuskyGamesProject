using UnityEngine;
using System.Collections;

public class EnemyBasicBullet : MonoBehaviour
{
	private float bSpeed; // Speed of the bullets
	private Rigidbody2D rb2d; // The bullets rigidbody2D

	void Start ()
	{
		// Get bullet speed from BulletInfo Script.
		bSpeed = gameObject.GetComponent<BulletInfo> ().bulletSpeed;
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
          
		// Check that the player is still alive
		if (GameObject.Find ("Player") != null)
		{
			//Get the players current position.
			var pos = GameObject.Find ("Player").transform.position;
			if (rb2d != null)
			{
				//Assuming this bullets rigidbody isn't null, set its velocity towards the detected player position.
				rb2d.velocity = (pos - transform.position).normalized * bSpeed;
			}
		}
		else if (rb2d != null)
		{
			//If player is dead, simply shoot forward.
			rb2d.velocity = transform.up * -bSpeed;
		}
	}

	// Update is called once per frame
	void Update () { }
}
