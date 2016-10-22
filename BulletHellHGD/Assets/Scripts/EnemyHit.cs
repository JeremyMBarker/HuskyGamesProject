using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {

    public float health;
        //The health a enemy has.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check to see if the enemy is colliding with a player bullet.
        if(other.gameObject.tag == "p_Bullet")
        {
            //Take out the bullets damage from the enemy's health, and then destroy the bullet.
            health = health - (other.gameObject.GetComponent<BulletInfo>().bulletDamage);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Player")
        {
            //If the player hits the enemy, destroy the enenmy.
            Destroy(this);
        }

           
    
        //Out of health points, therefore destroy enenmy.
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
