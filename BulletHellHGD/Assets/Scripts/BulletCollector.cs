using UnityEngine;
using System.Collections;

public class BulletCollector : MonoBehaviour {

	
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject.transform.parent.gameObject);
    }
}
