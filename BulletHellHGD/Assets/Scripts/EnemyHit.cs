using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {

    public float health;
    void OnTriggerEnter2D(Collider2D other)
    {
        health--;
        if(other.gameObject.transform.parent != null) { 
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else{
            //Destroy(other.gameObject);
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
