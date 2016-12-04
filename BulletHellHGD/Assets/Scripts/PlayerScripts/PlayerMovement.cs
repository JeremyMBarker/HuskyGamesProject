using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public Text pLivesText;
	public Text pScoreText;
	public float playerSpeed;
	public int pHealth;
	public int pScore;

	private Rigidbody2D rb2d;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		pHealth = 3;
		pScore = 0;
		SetPLivesText ();
		SetPScoreText ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "e_Bullet")
        {
            //Destroy the bullet object when it hits the player.
            if (other.gameObject.tag == "e_Bullet")
            {
                Destroy(other.gameObject);
            }
            dieAndRespawn();
        }
	}

	void dieAndRespawn ()
	{
		pHealth -= 1;
		SetPLivesText ();
		if (pHealth <= 0)
			Destroy (this.gameObject);
		else
			transform.position = new Vector3 ((float)-2.5, (float)-3, 0);
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		if (Input.GetKey (KeyCode.LeftShift))
			rb2d.velocity = (playerSpeed/(float)3 * movement);
		else
			rb2d.velocity = (playerSpeed * movement);
	}

	public void UpdatePlayerScore(int addedValue)
	{
		pScore+=addedValue;
		SetPScoreText();
	}

	void SetPScoreText ()
	{
		pScoreText.text = "" + pScore;
	}

	void SetPLivesText ()
	{
		pLivesText.text = "" + pHealth;
	}
}