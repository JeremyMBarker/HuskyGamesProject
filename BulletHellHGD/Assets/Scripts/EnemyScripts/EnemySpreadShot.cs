using UnityEngine;
using System.Collections;

public class EnemySpreadShot : MonoBehaviour
{
	[Range (0f, 360f)]
	public float spread_angle = 0f; // Angle of the spread of the shots
	/* i.e., If you want your bullets in a 45 degree cone then put in 45 */

	[Range (0f, 360f)]
	public float spread_center = 0f; // Where the center of the spread will start
	public bool targetPlayer; // Set true if the shot should center at players position
	public int numShots; // Number of bullets in the spread
	public GameObject Shot; // Type of shot
	public Transform BulletSpawn; // The Transform where bullets are instantiated
	public float fireRate; // Time between shots
	public float sleep; // Sleep time before firing
	private float nextFire; // Time when next fire is valid
	private float initTime; // Should shooting start yet
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
	{
		initTime = Time.time;
		// Set spread center when not targeting the player
		if (!targetPlayer)
			BulletSpawn.transform.Rotate (Vector3.forward * spread_center);
		else
			BulletSpawn.transform.Rotate (Vector3.forward * spread_center);
	}

	// Update is called once per frame
	void Update ()
	{
		if (Time.time > initTime + sleep)
		{
			//Determine if player is alive, and obtain player's transform.
			var p = GameObject.Find ("Player");
			if (p == null)
			{
				//Player must be dead.
				if (Time.time >= nextFire)
				{
					Instantiate (Shot, BulletSpawn.position, BulletSpawn.rotation);
					nextFire = Time.time + fireRate;
				}
			}
			else
			{
				var p_pos = p.transform; // Valid time to fire another spread.
				if (Time.time >= nextFire)
				{
					if (targetPlayer)
						BulletSpawn.transform.up = p_pos.position - transform.position;
					else { /* Set in Start */ }

					// Even shots have no center shot. Odd shots do.
					float anglePerShot;

					if (numShots == 0)
						return; // No need to fire.
					else if (numShots % 2 > 0)
					{
						//Odd number of shots.
						Instantiate (Shot, BulletSpawn.position, BulletSpawn.rotation);
						anglePerShot = (spread_angle / (numShots - 1));
					}
					else
					{
						//Even number of shots.
						anglePerShot = (spread_angle / numShots);
					}

					float minAngle = (spread_angle / 2) * -1;
					float maxAngle = (spread_angle / 2);

					for (float i = minAngle; i < 0; i = i + anglePerShot)
					{
						BulletSpawn.transform.Rotate (Vector3.forward * i);
						Instantiate (Shot, BulletSpawn.position, BulletSpawn.rotation);
						BulletSpawn.transform.Rotate (Vector3.forward * -i);
					}

					for (float i = maxAngle; i > 0; i = i - anglePerShot)
					{
						BulletSpawn.transform.Rotate (Vector3.forward * i);
						Instantiate (Shot, BulletSpawn.position, BulletSpawn.rotation);
						BulletSpawn.transform.Rotate (Vector3.forward * -i);
					}

					nextFire = Time.time + fireRate;
				}
			}
		}
	}
}