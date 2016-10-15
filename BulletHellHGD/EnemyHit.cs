using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHit : MonoBehaviour {

    public float health;
    public int scoreValue;
    public PlayerMovement playerMovement;
    

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
            playerMovement.addScore(scoreValue);
            Destroy(this.gameObject);
        }
        
    }
}
