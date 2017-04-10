using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawn : MonoBehaviour
{
	// lists of spawn points and enemy varieties
	public Transform[] spawnPoints;
	public GameObject[] enemies;

	// other useful variables
	public float time_between_spawn;
	public int max_enemy_count;
	private int current_enemy_count;

	// Use this for initialization
	void Start ()
	{
		// no enemies at start
		current_enemy_count = 0; 

		// continuously spawn enemies
		InvokeRepeating("Spawn", 3f, time_between_spawn);
	}

	private void Spawn ()
	{
		if (current_enemy_count != max_enemy_count)
		{
			// set random spawn point as 'a'
			int a = Random.Range (0, spawnPoints.Length);

			// set random enemy type as 'b'
			int b = Random.Range (0, enemies.Length);

			// Spawn an enemy
			current_enemy_count++;
			Instantiate (enemies[b], spawnPoints [a].position, spawnPoints [a].rotation);
		}
	}

	public void KillEnemy ()
	{
		current_enemy_count--;
	}

	// destroy this manager which generates enemies
	public void HaltSpawning()
	{
		Destroy (this);
	}
}
