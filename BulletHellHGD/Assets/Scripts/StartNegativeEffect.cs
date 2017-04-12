using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNegativeEffect : MonoBehaviour {
    private GameObject camera;
	// Use this for initialization
	void Start () {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            camera.GetComponent<PowerDown>().runNegEffect();
            Destroy(this.gameObject);
        }
    }


}
