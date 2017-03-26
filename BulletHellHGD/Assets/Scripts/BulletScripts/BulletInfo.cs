using UnityEngine;
using System.Collections;

//Currently this class stores a bullet's damage and speed.
public class BulletInfo : MonoBehaviour
{
	public int bulletDamage;
	public float bulletSpeed;
    private int maxBulletDamage;
    private int initBulletDamage;
    public bool poweredUp = false;
    public float powerUpEnd;
    // Use this for initialization
    void Start () {
        initBulletDamage = 1;
        bulletDamage = initBulletDamage;
        maxBulletDamage = bulletDamage * 2;
        poweredUp = false; 

    }
	
	// Update is called once per frame
	void Update () {

        if(bulletDamage > maxBulletDamage)
        {
            bulletDamage = maxBulletDamage;
        }

        if (Time.time >= powerUpEnd && poweredUp == true)
        {
            poweredUp = false;
            bulletDamage = initBulletDamage;
        }

    }



}
