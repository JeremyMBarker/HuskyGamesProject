using UnityEngine;
using System.Collections;

public class demoscript : MonoBehaviour {

	public PlayerMovement player;

	// Use this for initialization
	void Start ()
	{
		player = FindObjectOfType<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(player.pHealth <= 0)
		{
			
		}
	}
}
