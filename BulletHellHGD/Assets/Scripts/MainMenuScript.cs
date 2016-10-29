using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainMenuScript : MonoBehaviour {

	public GameObject playBut;
	public GameObject optionBut;
	public GameObject exitBut;

	//hold original position value
	private Vector3 playPos;
	private Vector3 optionPos;
	private Vector3 exitPos;
	//Resolution res;
	// Use this for initialization
	void Start () {
		playPos = new Vector3(playBut.transform.position.x, playBut.transform.position.y, playBut.transform.position.z);
		optionPos = new Vector3(optionBut.transform.position.x, optionBut.transform.position.y, optionBut.transform.position.z);
		exitPos = new Vector3(exitBut.transform.position.x, exitBut.transform.position.y, exitBut.transform.position.z);
	}
	// Update is called once per frame
	void Update () {
		if(buttonScript.moving == 1){
			//move play Button
			Vector3 translate = new Vector3(playPos.x, playPos.y + 100000, playPos.z);
			Vector3 origin = new Vector3(playPos.x, playPos.y, playPos.z);
			GameObject button = GameObject.FindGameObjectWithTag("playButton");
			button.transform.position =  Vector3.Lerp(origin, translate, 0.01f * Time.deltaTime);
		}
	}
}
