using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public int bossHealth;
    public int scoreValue;
    private GameManager game_manager;
    private EnemySpawning enemyManager;
    public GameObject Shot; // Type of shot
    public Transform BulletSpawnL; // The Transform where bullets are instantiated (left side)
    public Transform BulletSpawnR; // The Transform where bullets are instantiated (right side)
    public Transform BulletSpawnM; // The Transform where bullets are instantiated (right side)
    public float sweepFireRate; // Time between shots(spread)
    public float staggerFireRate; // Time between shots(stagger)
    public float timeBetweenAttack; // Amount of time between doing an attack
    private float nextFire; // Time when next fire is valid
    public int shotsInAOE;
    private Rigidbody2D rb2d;
    public float sweepAngle; // Angle the spread shot will go before returning to it's starting angle.
    public float AOEMinDelay; // Minimum time between AoE waves
    public float AOEMaxDelay; // Max time between AoE waves
    public float AOEWaves; // number of AoE waves
    public float staggerWaves; // # of waves of bullets per stagger shot
    public float shotsPerSweep;
    private bool firing;
    // Use this for initialization
    void Start () {
        firing = false;
        enemyManager = FindObjectOfType<EnemySpawning>();
        game_manager = FindObjectOfType<GameManager>();
        nextFire = Time.time;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check to see if the enemy is colliding with a player bullet.
        if (other.gameObject.tag == "p_Bullet")
        {
            // Take out the bullets damage from the enemy's health, and then destroy the bullet.
            bossHealth = bossHealth - (other.gameObject.GetComponent<BulletInfo>().bulletDamage);
            Destroy(other.gameObject);
        }

        // Out of health points, therefore destroy enenmy.
        if (bossHealth <= 0)
        {
            game_manager.UpdateScore(scoreValue);
            Destroy(this.gameObject);
        }
    }



    // Update is called once per frame
    void Update () {

        if (firing)
        {
            nextFire = Time.time + timeBetweenAttack;
        }
        if (!(Time.time >= nextFire) || firing == true)
        {
            return;
        }

        int attack;
        attack = Random.Range(0, 3);
        
        switch (attack)
        {
            case 0:
               
                  firing = true;
                  StartCoroutine(AOE());
                break;
                
            case 1:


                firing = true;
                StartCoroutine(sweepShot());
                
                break;
            case 2:


                firing = true;
                StartCoroutine(staggerShot());
                    
                
                break;


        }

        


    }

    IEnumerator AOE()
    {
        float angle = 180;
        float anglePerShot = angle / shotsInAOE;



        float minAngle = (angle / 2) * -1;
        float maxAngle = (angle / 2);

        for (int j = 0; j < AOEWaves; j++)
        {


            for (float i = minAngle; i < 0; i = i + anglePerShot)
            {
                BulletSpawnM.transform.Rotate(Vector3.forward * i);
                Instantiate(Shot, BulletSpawnM.position, BulletSpawnM.rotation);
                BulletSpawnM.transform.Rotate(Vector3.forward * -i);
            }

            for (float i = maxAngle; i > 0; i = i - anglePerShot)
            {
                BulletSpawnM.transform.Rotate(Vector3.forward * i);
                Instantiate(Shot, BulletSpawnM.position, BulletSpawnM.rotation);
                BulletSpawnM.transform.Rotate(Vector3.forward * -i);
            }

            float delay = Random.Range(AOEMinDelay, AOEMaxDelay);

            yield return new WaitForSeconds(delay);

        }
        firing = false;
    }
     IEnumerator sweepShot()
    {
        float startTime = Time.time;    
        var initL = BulletSpawnL.rotation;
        var initR = BulletSpawnR.rotation;

        float anglePerShot = sweepAngle / shotsPerSweep;
        
        

        for (float i = 0; i < sweepAngle; i = i + anglePerShot)
        {
     
            BulletSpawnR.transform.Rotate(Vector3.forward * i);
            Instantiate(Shot, BulletSpawnR.position, BulletSpawnR.rotation);
            BulletSpawnR.transform.Rotate(Vector3.forward * -i);

            BulletSpawnL.transform.Rotate(Vector3.forward * -i);
            Instantiate(Shot, BulletSpawnL.position, BulletSpawnL.rotation);
            BulletSpawnL.transform.Rotate(Vector3.forward * i);
            yield return new WaitForSeconds(sweepFireRate);
         
        }

        for (float i = sweepAngle; i > 0; i = i - anglePerShot)
        {

            BulletSpawnR.transform.Rotate(Vector3.forward * i);
            Instantiate(Shot, BulletSpawnR.position, BulletSpawnR.rotation);
            BulletSpawnR.transform.Rotate(Vector3.forward * -i);

            BulletSpawnL.transform.Rotate(Vector3.forward * -i);
            Instantiate(Shot, BulletSpawnL.position, BulletSpawnL.rotation);
            BulletSpawnL.transform.Rotate(Vector3.forward * i);
            yield return new WaitForSeconds(sweepFireRate);

        }
        firing = false;
    }

    IEnumerator staggerShot()
    {
        Transform[] bSpawns = new Transform[3];

        bSpawns[0] = BulletSpawnL;
        bSpawns[1] = BulletSpawnM;
        bSpawns[2] = BulletSpawnR;


        for (int i = 0; i < staggerWaves; i++)
        {
            int r = Random.Range(0, 3); // will be 0 - 2, int is exclusive on the max.
            int shotsFired = 0;
            while (shotsFired != 3)
            {

                var currentBulletSpawn = bSpawns[r % 3];
                Instantiate(Shot, currentBulletSpawn.position, currentBulletSpawn.rotation);
                r++;
                shotsFired++;
                yield return new WaitForSeconds(staggerFireRate);
                


            }


        }
        firing = false;
    }
}
