using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour
{

	public float scrollSpeed;
	public float tileSize;

	private Vector2 startPosition;

	void Start ()
	{
		startPosition = transform.position;
	}
	
	void Update ()
	{
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSize);
		transform.position = startPosition + Vector2.down * newPosition;
	}
}
