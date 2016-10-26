using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public PlayerMovement playerHealth; 
    public GameObject enemy; 
    public float spawnTime = 3f;
    public Transform[] spawnPoints; 


	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime); 
	}
	

    void Spawn () {
        if(playerHealth.pHealth <= 0f) {
            return;
        }
        //Find a random index to spawn at between zero and the 
        //number of spawn points 
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //creates an instance of the enemy at a random spawn point
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }


	// Update is called once per frame
	void Update () {
	
	}
}
