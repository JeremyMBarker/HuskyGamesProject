using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public GameObject Shot; // Type of shot
    public Transform BulletSpawnL; // The Transform where bullets are instantiated (left side)
    public Transform BulletSpawnR; // The Transform where bullets are instantiated (right side)
    public Transform BulletSpawnM; // The Transform where bullets are instantiated (right side)
    public float fireRate; // Time between shots
    public float timeBetweenAttack; // Amount of time between doing an attack
    private float nextFire; // Time when next fire is valid
    private float initTime; // Should shooting start yet
    public int shotsInAOE;
    private Rigidbody2D rb2d;
    public float sweepAngle;
    public float sweepShotDelay;
    private bool run;
    // Use this for initialization
    void Start () {
        run = false;
	}
	
	// Update is called once per frame
	void Update () {
        int attack;
        attack = Random.Range(0, 3);
        attack = 1;
        
        switch (attack)
        {
            case 0:
                if (!run)
                {
                    run = true;
                    AOE();
                }
                break;
                
            case 1:
                if (!run)
                {
                    run = true;
                    StartCoroutine(sweepShotL());
                }
                break;
            case 2:
                //attackThree();
                break;


        }

		
	}

    void AOE()
    {
        float angle = 180;
        float anglePerShot =   angle / shotsInAOE;

        

        float minAngle = (angle / 2) * -1;
        float maxAngle = (angle / 2);

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

    }

     IEnumerator sweepShotL()
    {
        float startTime = Time.time;    
        var initL = BulletSpawnL.rotation;
        var initR = BulletSpawnR.rotation;

        
        

        for (float i = 0; i < sweepAngle; i = i + 5)
        {
     
            BulletSpawnR.transform.Rotate(Vector3.forward * i);
            Instantiate(Shot, BulletSpawnR.position, BulletSpawnR.rotation);
            BulletSpawnR.transform.Rotate(Vector3.forward * -i);

            BulletSpawnL.transform.Rotate(Vector3.forward * -i);
            Instantiate(Shot, BulletSpawnL.position, BulletSpawnL.rotation);
            BulletSpawnL.transform.Rotate(Vector3.forward * i);
            yield return new WaitForSeconds(.5f);
         
        }

        for (float i = sweepAngle; i > 0; i = i - 5)
        {

            BulletSpawnR.transform.Rotate(Vector3.forward * i);
            Instantiate(Shot, BulletSpawnR.position, BulletSpawnR.rotation);
            BulletSpawnR.transform.Rotate(Vector3.forward * -i);

            BulletSpawnL.transform.Rotate(Vector3.forward * -i);
            Instantiate(Shot, BulletSpawnL.position, BulletSpawnL.rotation);
            BulletSpawnL.transform.Rotate(Vector3.forward * i);
            yield return new WaitForSeconds(.5f);

        }

    }
}
