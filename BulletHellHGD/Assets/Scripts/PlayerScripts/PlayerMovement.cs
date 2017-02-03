using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float playerSpeed;

	// have a reference to the Game Manager
	public GameManager game_manager;

	private Rigidbody2D rb2d;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		game_manager = FindObjectOfType<GameManager> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// When player collides with an object
        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "e_Bullet")
        {
            // Destroy the bullet object when it hits the player.
            if (other.gameObject.tag == "e_Bullet")
            {
                Destroy(other.gameObject);
            }
			game_manager.UpdateLives (-1);
			Respawn ();
        }
	}

	void FixedUpdate ()
	{
		// Get input for player movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		if (Input.GetKey (KeyCode.LeftShift))
			rb2d.velocity = (playerSpeed/(float)3 * movement);
		else
			rb2d.velocity = (playerSpeed * movement);
	}

	private void Respawn ()
	{
		transform.position = new Vector3 ((float)-2.5, (float)-3, 0);
	}
}