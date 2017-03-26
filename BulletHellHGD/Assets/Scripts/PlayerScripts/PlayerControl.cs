
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    // have a reference to the Game Manager
    public GameManager game_manager;
    public boolean immune = false;
    public float playerSpeed;
    float immuneTime; // = 1.125f;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        game_manager = FindObjectOfType<GameManager>();
    }
    function Update()
    {
        if (!immune) { return; }
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) // This might need to be == if we want unending immunity
        {
            immune = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // When player collides with an object
        if (immune) { return; }
        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "e_Bullet")
        {
            // Destroy the bullet object when it hits the player.
            if (other.gameObject.tag == "e_Bullet")
            {
                Destroy(other.gameObject);
            }
            game_manager.UpdateLives(-1);
            Respawn();
        }
    }

    void FixedUpdate()
    {
        // Get input for player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (Input.GetKey(KeyCode.LeftShift))
            rb2d.velocity = (playerSpeed / (float)3 * movement);
        else
            rb2d.velocity = (playerSpeed * movement);
    }

    private void Respawn()
    {
        immune = true;
        immuneTime = 1.125f;
        transform.position = new Vector3((float)-2.5, (float)-3, 0);

    }
}

