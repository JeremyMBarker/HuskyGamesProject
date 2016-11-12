using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Shot; // Holds the prefab for a type of bullet/ shot
    public Transform BulletSpawn; // The transform of the area where bullets from out of the player
    public float fireRate; // FireRate is the delay between shots, in seconds
    public float spread = 0.5f; // The +/- between the two bullets in double shot
    private float nextFire; // tracks time waited to help calculate next shot
    public float timeBeforePower; // Time before next powerup spawns.
    private float initTime; // Time when Player first begins
    public float initFire;
    public GameObject Power_Up;
    void Start()
    {
        initTime = Time.time;
        initFire = fireRate;
    }

    void Update()
    {
        if (Time.time > initTime + timeBeforePower)
        {
            initTime = Time.time;
            powerUp();

        }

        if (Input.GetKey(KeyCode.Z) && Time.time > nextFire)
        {
            // Z shoots 2 shots side by side
            doubleShot();
        }
        else if (Input.GetKey(KeyCode.X) && Time.time > nextFire)
        {
            //Space will shoot 2 shots angled +- 45 degrees
            splitShot();
        }
    }

    void doubleShot()
    {
        // Simply create a bullet in the forward direction
        nextFire = Time.time + fireRate;
        var t1 = BulletSpawn.position;
        t1.x = t1.x - spread;
        var t2 = BulletSpawn.position;
        t2.x = t2.x + spread;
        Instantiate(Shot, t1, BulletSpawn.rotation);
        Instantiate(Shot, t2, BulletSpawn.rotation);
    }

    void splitShot()
    {
        nextFire = Time.time + fireRate;
        //Create a bullet +45 degrees, -45degrees, then set the BulletSpawn's rotation back to forwrd.
        BulletSpawn.transform.Rotate(Vector3.forward * -45);
        Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
        BulletSpawn.transform.Rotate(Vector3.forward * 90);
        Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
        BulletSpawn.transform.Rotate(Vector3.forward * -45);
    }
    void powerUp()
    {
        var t = transform.position;
        t.y = t.y - 2;
        Instantiate(Power_Up, t, transform.rotation);

    }

}