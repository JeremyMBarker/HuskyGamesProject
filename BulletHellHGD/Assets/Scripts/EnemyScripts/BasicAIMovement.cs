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
	public int positions = 0;
    public float startTime;
    int retreat = 0;
    public float DistTravel = 0f;
    public float DistTravel2 = 0f;
    public int retreatTime = 15; 
    Vector3 End_Pos;
    Vector3 Start_Pos; 

	private void Start()
	{
        Start_Pos = transform.position;
        End_Pos = transform.position + new Vector3(0, -4, 0);
        startTime = Time.time;
        retreat = 0;

		target = GameObject.Find("Player").transform;

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
		
		else if(level == 2)
		{
            if (DistTravel < 10f)
            {
                DistTravel += .01f; //Adjust this for how fast you want it to be.
                transform.position = Vector3.Lerp(Start_Pos, End_Pos, DistTravel);
            }
            if (Time.time - startTime > retreatTime)
            { 
            retreat = 1;
            }
            if (retreat == 1)
            {
                if (transform.position.y >=5)
                {
                    Destroy(this.gameObject);
                }

                if (DistTravel2 < 5)
                {
                    DistTravel2 += .01f;
                    transform.position = Vector3.Lerp(End_Pos, Start_Pos, DistTravel2);
                }                
            }
		}
	}

}
