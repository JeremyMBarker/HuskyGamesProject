using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
    private int shotCount;
    //Note: AOE = Area of Effect, refers to things that affects the area around something in a radius.
    //So in this instance, we're making a circle of bullets around the enemy. 
        //Shots since last AOE attack.
    public int shotsBeforeAOE;
        //How many regular shots will occur before an AOE attack.
    public int numShotsAOE;
        //Number of bullets in an AOE attack.
    public GameObject Shot;
        //The type of shot for regular attacks.
    public GameObject AOEShot;
        //The type of shot for AOE attacks.
    public Transform BulletSpawn;
        //The transform of the area where bullets from out of an enemy.
    public float fireRate;
        //Time between shots.
    private float nextFire;
        //Determines the Time.time needed to shoot again.
    private Rigidbody2D rb2d;
    // Use this for initialization
    void Start()
    {
        shotCount = 0;
        //Just starting up, so no shots fired.

    }


    void Update()
    {
        
        //Check if it is valid to fire again.
        if (Time.time > nextFire)
        {
            //Check if enough shots have been fired to do an AOE, and if the enemy has an AOE attack (0 means no AOE).
            if (shotCount >= shotsBeforeAOE && shotsBeforeAOE != 0)
            {
                AOE();
                nextFire = Time.time + fireRate;
                //Reset count of shots before AOE to 0.
                shotCount = 0;
            }
            else
            {
                //If AOE is not valid, then do a regular shot.
                nextFire = Time.time + fireRate;
                shotCount = shotCount + 1;
                GameObject shoot = (GameObject)Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
            }
        }
    }

    void AOE()
    {
        //Breaks a circle up into segments = numShotsAOE. 
        //Then rotates an amount to fit that many shots in a 0 - 360 
        // degree radius. Each iteration sets the BulletSpawn to the
        // Proper location, spawns its bullet, then resets BulletSpawn.
		for (int i = 0; i <= 360; i += (360 / numShotsAOE))
        {            BulletSpawn.transform.Rotate(Vector3.forward * i);
            Object b = Instantiate(AOEShot, BulletSpawn.position, BulletSpawn.rotation);
            BulletSpawn.transform.Rotate(Vector3.forward * -i);

        }
    }
}
