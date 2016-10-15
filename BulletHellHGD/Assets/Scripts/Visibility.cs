using UnityEngine;
using System.Collections;

// makes an object visible when paused
public class Visibility : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale == 0)
			GetComponent<Renderer> ().enabled = true;
		else
			GetComponent<Renderer> ().enabled = false;
	}
}
