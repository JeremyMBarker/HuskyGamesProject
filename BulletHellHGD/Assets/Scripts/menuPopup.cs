using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuPopup : MonoBehaviour
{
	public Image menu;
	private bool status;
	private Button quit;
	private Button menuReturn;
	private Text label;
	private Text end_label;
	private bool isPaused = false;
	private bool gameEnd = false;

	// Use this for initialization
	void Start ()
	{
		status = false;
		menu = (Image)GetComponent<Image> ();
		menu.enabled = false;

		//get quit button
		quit = (Button)GameObject.Find ("quitButton").GetComponent<Button> ();
		hideButton (quit);

		//get menuReturn button
		menuReturn = (Button)GameObject.Find ("return").GetComponent<Button> ();
		hideButton (menuReturn);

		//get menu text
		label = (Text)GameObject.Find ("menuText").GetComponent<Text> ();
		end_label = (Text)GameObject.Find ("menu_GameOver").GetComponent<Text> ();
		label.enabled = false;
		end_label.enabled = false;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && !gameEnd)
		{
			//hide menu
			if (status)
			{
				menu.enabled = false;
				hideButton (quit);
				hideButton (menuReturn);
				status = false;
				label.enabled = false;
			}
			//reveal menu
			else
			{
				menu.enabled = true;
				revealButton (quit);
				revealButton (menuReturn);
				status = true;
				label.enabled = true;
			}

			if (isPaused)
			{
				Time.timeScale = 1;
				isPaused = false;
			}
			else
			{
				Time.timeScale = 0;
				isPaused = true;
			}
		}
	}

	//handles hiding buttons while menu is not active
	private void hideButton (Button button)
	{
		button.enabled = false;
		button.gameObject.SetActive (false);
	}
	//handles activating buttons while menu is active
	private void revealButton (Button button)
	{
		button.gameObject.SetActive (true);
		button.enabled = true;
	}

	public bool getIsPaused ()
	{
		return isPaused;
	}

	public void EndGame ()
	{
		// disable esc key
		gameEnd = true;
		// revel menu
		menu.enabled = true;
		revealButton (quit);
		revealButton (menuReturn);
		status = true;
		end_label.enabled = true;
		// pause the game
		Time.timeScale = 0;
		isPaused = true;
	}
}
