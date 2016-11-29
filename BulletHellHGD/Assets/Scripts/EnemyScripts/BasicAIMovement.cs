using UnityEngine;
using System.Collections;

public class BasicAIMovement : MonoBehaviour {

    private Vector3 pos1 = new Vector3(-9, 3, 0);
    private Vector3 pos2 = new Vector3(4, 3, 0);
    private bool started = false;
    public float speed = .1f;
    


    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            transform.position = Vector3.Lerp(transform.position, pos2, Mathf.PingPong(Time.time * speed, .5f));
        }
        if (transform.position == pos2)
        {
            started = true;
        }
        if (started)
        {
            transform.position = Vector3.Lerp(pos2, pos1, Mathf.PingPong(Time.time * speed, 1.0f));
        }
        
    }

}

