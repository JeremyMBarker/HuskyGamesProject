using UnityEngine;
using System.Collections;

public class EnemyMovementV2 : MonoBehaviour {

    public Transform[] Waypoints;
    public float speed;
    public int curWaypoint;
    public bool patrol = true;
    public Vector3 Target;
    public Vector3 MoveDirection;
    public Vector3 Velocity; 

    	void Update () {
    if(curWaypoint < Waypoints.Length)
        {
            Target = Waypoints[curWaypoint].position;
            MoveDirection = Target - transform.position;
            Velocity = GetComponent < Rigidbody >().velocity;

            if (MoveDirection.magnitude < 1)
            {
                curWaypoint++;
            }
            else
            {
                Velocity = MoveDirection.normalized * speed;

            }
        }else
        {
            if (patrol)
            {
                curWaypoint = 0;
            }
            else
            {
                Velocity = Vector3.zero;
            }
        }
        GetComponent<Rigidbody>().velocity = Velocity;

	}
}
