using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{

	//Holds the prefab for a type of bullet/shot.
    public GameObject Shot;
	//The Transform of the area where bullets from out of the player.
	public Transform BulletSpawn;
	//fireRate is the delay between shots, in seconds.
    public float fireRate;
	//Tracks what Time.time should be for next shot to have waited fireRate amount of seconds.
    private float nextFire;

	// Use this for initialization
    void Start() { }

    void Update()
    {

        if (Input.GetKey(KeyCode.Z) && Time.time > nextFire)
        {
            // Z shoots currently a single shot in a straight line.
            singleShot();

        }
        else if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            //Space will shoot 2 shots angled +- 45 degrees.
            splitShot();
        }
    }

    void singleShot()
    {
        //Simply create a bullet in the forward direction.
        Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);

        nextFire = Time.time + fireRate;

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
}
