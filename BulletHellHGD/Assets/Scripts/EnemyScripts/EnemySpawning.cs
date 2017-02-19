using UnityEngine;
using System.Collections;

public class EnemySpawning : MonoBehaviour
{
	private PlayerControl player;
	private GameManager game_manager;
	public GameObject Enemy_Nurse;
	public GameObject Enemy_Doctor;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;
	public Transform[] MspawnPoints;
	private int enemyCount;
	private int randPos;
	private bool[] availablePos;
	public int testing = 0;
	// Use this for initialization
	void Start ()
	{ 
		player = FindObjectOfType<PlayerControl> ();
		enemyCount = 0;
		availablePos = new bool[spawnPoints.Length];
		for (int i = 0; i < spawnPoints.Length; i++)
			availablePos [i] = true; // initially any position is available
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn ()
	{
		//if (game_manager.GetLives() <= 0) return;

		enemyCount++;
		if (testing == 0)
		{
			if (enemyCount < spawnPoints.Length)
			{
				// Creates an instance of the enemy at a random spawn point
				randPos = Random.Range (0, spawnPoints.Length);
				while (!availablePos [randPos]) // while not an available position
				{
					randPos++;
					if (randPos == spawnPoints.Length)
					{
						randPos = 0;
					}
				}
				availablePos [randPos] = false;
				if (Random.Range (0, 2) == 0) // random number [0,2)
					Instantiate (Enemy_Nurse, spawnPoints [randPos].position, spawnPoints [randPos].rotation);
				else
					Instantiate (Enemy_Doctor, spawnPoints [randPos].position, spawnPoints [randPos].rotation);
			}
		}
		else if (testing == 1)
		{
			// Creates an instance of the enemy at a random spawn point
			randPos = Random.Range (0, MspawnPoints.Length);
			while (!availablePos [randPos]) // while not an available position
			{
				randPos++;
				if (randPos == MspawnPoints.Length)
				{
					randPos = 0;
				}
			}
			availablePos [randPos] = false;
			if (Random.Range (0, 2) == 0) // random number [0,2)
				Instantiate (Enemy_Nurse, MspawnPoints [randPos].position, MspawnPoints [randPos].rotation);
			else
				Instantiate (Enemy_Doctor, MspawnPoints [randPos].position, MspawnPoints [randPos].rotation);
		}

	}

	public int getCurrentPosition ()
	{
		return randPos;
	}

	public void killEnemy (int spawnPos)
	{
		enemyCount--;
		availablePos [spawnPos] = true;
	}
}