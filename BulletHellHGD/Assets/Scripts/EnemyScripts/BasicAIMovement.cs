using UnityEngine;
using System.Collections;

public class BasicAIMovement : MonoBehaviour {

    
    private Vector3 pos1 = new Vector3(-9, 3, 0);
    private Vector3 pos2 = new Vector3(4, 3, 0);
    public float speed = .1f;
    public Transform target;
    public float MaxDist = 5;
    public float MinDist = 3;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,target.position) >= MinDist)
        transform.position += (target.position - transform.position).normalized
               * speed * Time.deltaTime;
    
    }

}

