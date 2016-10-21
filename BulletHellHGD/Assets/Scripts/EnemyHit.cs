using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {

    public float health;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "p_Bullet")
        {
            health = health - (other.gameObject.GetComponent<BulletInfo>().bulletDamage);
        }

        Destroy(other.gameObject);    
    
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
