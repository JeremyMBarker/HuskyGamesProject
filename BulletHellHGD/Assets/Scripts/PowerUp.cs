using UnityEngine;
using System.Collections;


public class PowerUp : MonoBehaviour
{
    
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            int choose_power = Random.Range(0, 2);
            print(choose_power);
            switch (choose_power)
            {
                case 0:
                    other.gameObject.GetComponent<PlayerShoot>().fireRate = other.gameObject.GetComponent<PlayerShoot>().fireRate / 2;
                    Destroy(this.gameObject);
                    break;
                case 1:
                    other.gameObject.GetComponent<PlayerMovement>().playerSpeed *= 1.25f;
                    Destroy(this.gameObject);
                    break;
            }

        }
    }
}
    
