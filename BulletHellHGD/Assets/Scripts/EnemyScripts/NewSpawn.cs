using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawn : MonoBehaviour
{
	// lists of spawn points and enemy varieties
	public Transform[] spawnPoints;
	public GameObject[] enemies;

	// boss stuff
	public Transform boss_spawn;
	public GameObject boss_enemy;
	public float seconds_until_boss;
	private float start_time;
	private bool spawned_boss;

	// other useful variables
	public float time_between_spawn;
	public int max_enemy_count;
	private int current_enemy_count;

	// Use this for initialization
	void Start ()
	{
		// no enemies at start
		current_enemy_count = 0;
		spawned_boss = false;

		// approx. time when enemies stared spawning
		start_time = Time.time;

		// continuously spawn enemies
		InvokeRepeating ("Spawn", 3f, time_between_spawn);
	}

	private void Spawn ()
	{
		if (!spawned_boss && Time.time - start_time > seconds_until_boss)
		{
			// spawn boss and halt spawning other enemies
			Instantiate (boss_enemy, boss_spawn.position, boss_spawn.rotation);
			spawned_boss = true;
			HaltSpawning ();
		}

		if (current_enemy_count <= max_enemy_count)
		{
			// set random spawn point as 'a'
			int a = Random.Range (0, spawnPoints.Length);

			// set random enemy type as 'b'
			int b = Random.Range (0, enemies.Length);

			// Spawn an enemy
			current_enemy_count++;
			Instantiate (enemies [b], spawnPoints [a].position, spawnPoints [a].rotation);
		}
	}

	public void KillEnemy ()
	{
		current_enemy_count--;
	}

	public void KillBoss ()
	{
		FindObjectOfType<menuPopup> ().WinGame ();
		Destroy (this);
	}

	// destroy this manager which generates enemies
	public void HaltSpawning ()
	{
		max_enemy_count = 1;
	}
}
