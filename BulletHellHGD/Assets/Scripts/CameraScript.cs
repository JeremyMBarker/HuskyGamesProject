using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private float aspectRatio = 2.0f;
	// Use this for initialization
	void Start () {
		Camera cam = Camera.main;
		cam.aspect = aspectRatio;
	
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
