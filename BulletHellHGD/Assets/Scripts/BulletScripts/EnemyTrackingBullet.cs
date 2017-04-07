using UnityEngine;
using System.Collections;

public class EnemyTrackingBullet : MonoBehaviour
{
	// If True, bullet will continue to track players current position.
	private bool stopTrack = false;
	// Speed of the tracking bullet.
	private float bSpeed;
	// How long the bullet should track the player. After the time it will continue in a straight path.
	public float trackingTime;
	// How long before tracking should begin.
	public float trackDelay;
	// Holds value of when tracking began.
	private float startTime;
	// Time when bullet is instantiated.
	private float initTime;
	private Rigidbody2D rb2d;
	private bool isPlayerAlive;

	public PlayerControl player;

	// Initialize
	void Start ()
	{
		initTime = Time.time;
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		// Get the bullet speed from it's BulletInfo script.
		bSpeed = gameObject.GetComponent<BulletInfo> ().bulletSpeed;
		player = FindObjectOfType<PlayerControl> ();
		isPlayerAlive = true;

		if (Time.time >= initTime + trackDelay)
		{
			// If there is a player still, find it's position.
			if (isPlayerAlive)
			{
				var pos = player.transform.position;
				if (rb2d != null)
				{
					// Set the bulelts velocity in the direction of the player's position.
					rb2d.velocity = (pos - transform.position).normalized * bSpeed;
				}
				// Get time when tracking started.
				startTime = Time.time;
			}
			else
			{
				if (rb2d != null)
				{
					// If player is dead, simply shoot forward.
					rb2d.velocity = transform.forward * -bSpeed;
					startTime = Time.time;
				}
			}
		}
		else
			rb2d.velocity = (transform.up * bSpeed);
	}

	// Update is called once per frame
	void Update ()
	{
		if (Time.time >= initTime + trackDelay)
		{
			// If We have no player, or tracking is over, let the bullet continue to forward.
			if (!stopTrack || isPlayerAlive)
			{
				// Get the players current position
                if(player == null)
                {
                    return;
                }
				var pos = player.transform.position;

				// Check if tracking is still going.
				if (Time.time > (startTime + trackingTime))
					stopTrack = true;
				else
				{
					// Tracking is still going, set the bullets velocity towards the player's position.
					rb2d = gameObject.GetComponent<Rigidbody2D> ();
					if (rb2d != null)
						rb2d.velocity = (pos - transform.position).normalized * bSpeed;
				}
			}
		}
		else
			rb2d.velocity = (transform.up * bSpeed);
	}

	public void killPlayer() { isPlayerAlive = false; }
}
   