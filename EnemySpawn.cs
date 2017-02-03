using UnityEngine;
using System.Collections;


[System.Serializable]
class EnemySpawn : MonoBehaviour {
    public float startSpawn, endSpawn, spawnInterval;
    public GameObject Enemy;
    public int amountPerSpawn;
    public Vector3 spawnPos;
    [HideInInspector]
    public float nextSpawn;
    [HideInInspector]
    public int counter;

    public EnemySpawn[] spawns;
    
   public void setID(int Counter)
    {

    }

	void Update () {
	foreach (var e in spawns)
        {
            if ( (Time.time > e.startSpawn) && (Time.time < e.endSpawn) ) {
                if (e.nextSpawn > 0) e.nextSpawn -= Time.deltaTime;
                else
                {
                    for (int i = 0; i < e.amountPerSpawn; i++ )
                    {
                        e.nextSpawn += e.spawnInterval;
                        GameObject enemy = Instantiate(e.Enemy, e.spawnPos, Quaternion.identity) as GameObject;
                        enemy.GetComponent<Enemy>().setID(e.counter);
                        e.counter++;
                    }
                }
            }
        }
	}
}
