using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
    private int shotCount;
    public int shotsBeforeAOE;
    public int numShotsAOE;
    public GameObject Shot;
    public Transform BulletSpawn;
    public float fireRate;
    private float nextFire;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        shotCount = 0;

    }


    void Update()
    {
        

        if (Time.time > nextFire)
        {

            if (shotCount >= shotsBeforeAOE && shotsBeforeAOE != 0)
            {
                AOE();
                nextFire = Time.time + fireRate;
                shotCount = 0;
            }
            else
            {
                nextFire = Time.time + fireRate;
                GameObject shoot = (GameObject)Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
            }
        }
    }

    void AOE()
    {
    
    }
}
