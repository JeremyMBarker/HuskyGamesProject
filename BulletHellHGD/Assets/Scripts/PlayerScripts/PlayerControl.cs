using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	// have a reference to the Game Manager
	public GameManager game_manager;

	// reference to sometimes invisible objects
	public GameObject shield_item;
	public GameObject kill_spot;

	public float playerSpeed;
	public float maxSpeed;
	public bool poweredUpShield = false;
	public bool poweredUpSpeed = false;
	public float powerUpEndSpeed;
	public float powerUpEndShield;
	private Rigidbody2D rb2d;
	private float initSpeed;
    public float invincibleTime;
    private float readyForDamage;
    public bool isInvincible;

    void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		game_manager = FindObjectOfType<GameManager> ();

		// set speed info
		maxSpeed = playerSpeed * 1.5f;
		initSpeed = playerSpeed;
		kill_spot.GetComponent<SpriteRenderer> ().enabled = false;

		// set shield info
		shield_item.GetComponent<SpriteRenderer> ().enabled = false;

        //Set invincible to false
        isInvincible = false;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// When player collides with an object
		if (other.gameObject.tag == "enemy" || other.gameObject.tag == "e_Bullet")
		{
			// Destroy the bullet object when it hits the player.
			if (other.gameObject.tag == "e_Bullet")
			{
				Destroy (other.gameObject);
			}
            //If player is set to be invincible, ignore damage.
            if (isInvincible)
            {
                return;
            }
            //If the player has a shield on, remove shield and damage is nulled
            if (poweredUpShield)
			{
				shield_item.GetComponent<SpriteRenderer> ().enabled = false;
				poweredUpShield = false;
				return;
			}
            //Player collision killing enemies is done here, to avoid weird "race conditions" with invincibility.
            if (other.tag == "enemy")
            {
                other.GetComponent<EnemyHit>().contactKillEnemy();
            }
            game_manager.UpdateLives (-1);
			Respawn ();
		}
	}

	void FixedUpdate ()
	{
        //Check if invincibility is over.
        if (Time.time >= readyForDamage)
        {
            isInvincible = false;
        }

        if (playerSpeed > maxSpeed) //Since fireRate is delay between shots, smaller values mean faster shooting.
		{
			playerSpeed = maxSpeed;
		}

		if (Time.time >= powerUpEndSpeed)
		{
			poweredUpSpeed = false;
			playerSpeed = initSpeed;
		}
		// timeout for shield
		/*if (Time.time >= powerUpEndShield && poweredUpShield == true)
		{
			shield_item.GetComponent<SpriteRenderer> ().enabled = false;
			poweredUpShield = false;
		}*/
		// Get input for player movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		if (Input.GetKey (KeyCode.LeftShift))
		{
			rb2d.velocity = (playerSpeed / (float)3 * movement);
			kill_spot.GetComponent<SpriteRenderer> ().enabled = true;
		}
		else
		{
			rb2d.velocity = (playerSpeed * movement);
			kill_spot.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	private void Respawn ()
	{
		transform.position = new Vector3 ((float)-2.5, (float)-3, 0);
        readyForDamage = Time.time + invincibleTime;
        isInvincible = true;
    }
}