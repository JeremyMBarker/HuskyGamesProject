using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour
{

	public PlayerMovement player;
	public EnemySpawning enemyManager;
	public float health;
	public int scoreValue;

	private int spawnPos;

	// Use this for initialization
	void Start ()
	{
		enemyManager = FindObjectOfType<EnemySpawning> ();
		spawnPos = enemyManager.getCurrentPosition ();
		player = FindObjectOfType<PlayerMovement> ();

		if (player.pScore > 2500)
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
			enemyManager.killEnemy (spawnPos);
			scoreValue = -500; player.UpdatePlayerScore (scoreValue);
			Destroy (this.gameObject);
		}

        //Out of health points, therefore destroy enenmy.
        if (health <= 0)
        {
            onDeath();
        }
    }


    void onDeath()
    {
        gameObject.GetComponent<PowerUp>().SpawnPowerup(this.transform);
        enemyManager.killEnemy(spawnPos);
        player.UpdatePlayerScore(scoreValue);
        Destroy(this.gameObject);

    }

}
