using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2d;
	private float playerSpeed;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") { 
			dieAndRespawn ();
		}
	}

		void dieAndRespawn(){
			transform.position = new Vector3(0,0,0);
		}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		if (Input.GetKey (KeyCode.LeftShift)) {
			playerSpeed = speed / (float)3;
		} else {
			playerSpeed = speed;
		}
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.velocity = (playerSpeed * movement);
	}

}
