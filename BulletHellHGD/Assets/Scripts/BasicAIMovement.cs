using UnityEngine;
using System.Collections;

public class BasicAIMovement : MonoBehaviour {

    private Vector3 pos1 = new Vector3(-9, 4, 0);
    private Vector3 pos2 = new Vector3(4, 4, 0);
    public float speed = .1f;


    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }

}

