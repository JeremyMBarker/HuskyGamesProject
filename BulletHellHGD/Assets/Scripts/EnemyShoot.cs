using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

    public GameObject Shot;
    public Transform BulletSpawn;
    public float fireRate;
    private float nextFire;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {


    }


    void Update()
    {
        

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject shoot = (GameObject) Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
        }
    }
}
