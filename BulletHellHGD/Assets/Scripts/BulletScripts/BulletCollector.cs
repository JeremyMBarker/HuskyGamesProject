using UnityEngine;
using System.Collections;

public class BulletCollector : MonoBehaviour {

    //If some object enters the collider zone, it will be
    // destroyed. Meant to clean up bullets.

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
