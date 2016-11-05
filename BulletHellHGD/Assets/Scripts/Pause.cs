using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	private bool isPaused = false;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("p"))
			isPaused = !isPaused;

		if (isPaused)
		{
			Time.timeScale = 0;
			// Do something menu related
		}
		else
			Time.timeScale = 1;
	}
}