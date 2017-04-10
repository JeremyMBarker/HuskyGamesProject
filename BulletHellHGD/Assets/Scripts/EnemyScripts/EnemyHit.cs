using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour
{

	private PlayerControl player;
	private GameManager game_manager;
	private NewSpawn enemyManager;
	public float health;
	public int scoreValue;

	private int spawnPos;

	// Use this for initialization
	void Start ()
	{
		enemyManager = FindObjectOfType<NewSpawn> ();

		player = FindObjectOfType<PlayerControl> ();
		game_manager = FindObjectOfType<GameManager> ();

		if (game_manager.GetScore() > 2500)
		{
			health *= 1.5f;
			scoreValue = (int)(scoreValue*1.5f);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// Check to see if the enemy is colliding with a player bullet.
		if (other.gameObject.tag == "p_Bullet")
		{
			// Take out the bullets damage from the enemy's health, and then destroy the bullet.
			health = health - (other.gameObject.GetComponent<BulletInfo> ().bulletDamage);
			Destroy (other.gameObject);
		}
		else if (other.gameObject.tag == "Player")
		{
			// If the player hits the enemy, destroy the enenmy.
			enemyManager.KillEnemy();
			game_manager.UpdateScore (-500);
			Destroy (this.gameObject);
		}

		// Out of health points, therefore destroy enenmy.
		if (health <= 0)
		{
			//Trigger power-up spawns
			gameObject.GetComponent<PowerUp>().SpawnPowerup(this.transform);

			enemyManager.KillEnemy ();
			game_manager.UpdateScore (scoreValue);
			Destroy (this.gameObject);
		}
	}
}