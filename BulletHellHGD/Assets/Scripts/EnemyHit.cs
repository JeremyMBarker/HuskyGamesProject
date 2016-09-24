using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {

    public float health;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            health = health - (other.gameObject.GetComponent<BulletInfo>().bulletDamage);
        }
       
        if(other.gameObject.transform.parent != null) { 
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else{
            
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
