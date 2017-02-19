using UnityEngine;
using System.Collections;

public class BasicAIMovement : MonoBehaviour {

	public EnemySpawning spot;
	private Vector3 pos1 = new Vector3(-9, 3, 0);
	private Vector3 pos2 = new Vector3(4, 3, 0);
	public float speed = .1f;
	public Transform target;
	public float MaxDist = 5;
	public float MinDist = 5;
	public float level = 0;
	public Transform[] TopLeftCorner;
	public Transform[] TopRightCorner;
	public Transform[] BottomLeftCorner;
	public Transform[] BottomRightCorner;
	public int positions = 0;
	int i = 0;
	int j = 0;
	int k = 0;
	int l = 0; 
	private void Start()
	{
		target = GameObject.Find("Player").transform;
		positions = spot.getCurrentPosition();

	}
	// Update is called once per frame
	void Update()
	{
		if (level == 0)
		{
			if (Vector3.Distance(transform.position, target.position) >= MinDist)
				transform.position += (target.position - transform.position).normalized
					* speed * Time.deltaTime;
		}
		else if(level == 1)
		{
			if (positions == 0)
			{
				if (Vector3.Distance(transform.position, TopLeftCorner[i].position) != 0)
				{
					transform.position += (TopLeftCorner[i].position - transform.position).normalized
						* speed * Time.deltaTime;
				}
				if (Vector3.Distance(transform.position, TopLeftCorner[i].position) == 0)
				{
					i = i + 1;
				}
				if (Vector3.Distance(transform.position, TopLeftCorner[4].position) == 0)
				{
					Destroy(this.gameObject);
				}
			}
			else if(positions == 1)
			{
				if (Vector3.Distance(transform.position, TopRightCorner[j].position) != 0)
				{
					transform.position += (TopRightCorner[j].position - transform.position).normalized
						* speed * Time.deltaTime;
				}
				if (Vector3.Distance(transform.position, TopRightCorner[j].position) == 0)
				{
					j = j + 1;
				}
				if (Vector3.Distance(transform.position, TopRightCorner[4].position) == 0)
				{
					Destroy(this.gameObject);
				}
			}
			else if(positions == 2)
			{
				if (Vector3.Distance(transform.position, BottomRightCorner[k].position) != 0)
				{
					transform.position += (BottomRightCorner[k].position - transform.position).normalized
						* speed * Time.deltaTime;
				}
				if (Vector3.Distance(transform.position, BottomRightCorner[k].position) == 0)
				{
					k = k + 1;
				}
				if (Vector3.Distance(transform.position, BottomRightCorner[4].position) == 0)
				{
					Destroy(this.gameObject);
				}
			}
			else if(positions == 3)
			{
				if (Vector3.Distance(transform.position, BottomLeftCorner[l].position) != 0)
				{
					transform.position += (BottomLeftCorner[l].position - transform.position).normalized
						* speed * Time.deltaTime;
				}
				if (Vector3.Distance(transform.position, BottomLeftCorner[l].position) == 0)
				{
					l = l + 1;
				}
				if(Vector3.Distance(transform.position, BottomLeftCorner[4].position) == 0)
				{
					Destroy(this.gameObject);
				}
			}
		}
		else if(level == 2)
		{

		}
	}

}
