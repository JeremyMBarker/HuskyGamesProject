using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// makes an object visible when paused
public class Visibility : MonoBehaviour {
	public GameObject ImageObject;
	public Sprite sprt;
	private Image img;
	private Color color;
	private Pause p;
	public GameObject pauseControl;
	private menuPopup menuIsPaused;
	// Update is called once per frame
	void Start(){
		img = (Image)ImageObject.GetComponent<Image>();

		img.sprite = sprt;
		img.color = color;
		p = transform.GetComponent<Pause>();

		menuIsPaused = (menuPopup)pauseControl.GetComponent<menuPopup>();

	}
	void Update () {

		if (Time.timeScale == 0 && !menuIsPaused.getIsPaused()){

			img.color = Color.white;

		}
		else{
			//GetComponent<Renderer> ().enabled = false;
			img.color = new Color(0,0,0,0);
		}

	}


}
