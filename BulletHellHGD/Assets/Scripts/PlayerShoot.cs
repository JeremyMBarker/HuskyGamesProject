using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public GameObject Shot;
    public Transform BulletSpawn;
    public float fireRate;
    private float nextFire;
	// Use this for initialization
	void Start () {

	
	}
	
	
	void Update () {
	
       if (Input.GetButton("Jump") && Time.time > nextFire)  {

            nextFire = Time.time + fireRate;
            Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
        }
	}
}
