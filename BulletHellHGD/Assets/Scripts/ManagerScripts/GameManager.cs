using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Manager Class that holds all general information about the game
 * and its progrssion. Any variables and methods that impact the
 * UI and other elements directly related to the person playing the
 * game should be kept here.
 */

public class GameManager : MonoBehaviour
{
	/* global variables */

	// UI elements
	public Text hud_score_text;
	public Text hud_lives_text;
	public Text hud_level_text;

	// player character elements
	private int player_score;
	private int player_lives;

	// game progression elementss
	/* difficulty should range from ?-? */
	private int difficultly;

	// have a reference to the player object
	public PlayerMovement player;

	// Use this for initialization
	void Start ()
	{
		player_score = 0;
		hud_score_text.text = "" + player_score;
		player_lives = 3;
		hud_lives_text.text = "" + player_lives;
		hud_level_text.text = "prototype";
		player = FindObjectOfType<PlayerMovement> ();
	}

	/* Method for updating the player's score which is displayed in the HUD
	 * parameter: int value - value of the score to be added (can be negative) */
	public void UpdateScore (int value)
	{
		player_score += value;
		hud_score_text.text = "" + player_score;
	}

	/* Method for obtaining the player's score which is displayed in the HUD */
	public int GetScore ()
	{
		return player_score;
	}

	/* Method for updating the player's lives which is displayed in the HUD
	 * Kills the player when lives reach 0
	 * parameter: int value - value to be applied to lives (usually negative) */
	public void UpdateLives (int value)
	{
		player_lives += value;
		hud_lives_text.text = "" + player_lives;

		// kill player object if health is zero
		if (player_lives <= 0)
			Destroy (player.gameObject);
	}

	/* Method for obtaining the player's lives which is displayed in the HUD */
	public int GetLives ()
	{
		return player_lives;
	}
}
