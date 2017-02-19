using UnityEngine;
using System.Collections;

static class Constants
{
    public const int SHOTSPEED = 0;
    public const int PLAYERSPEED = 1;

    public const int MAX = 1; // This is our highest static power-up value.
    

}


public class PowerUp : MonoBehaviour
{
    public GameObject SHOTSPEED_POWERUP;
    public GameObject PLAYSERSPEED_POWERUP;
    [Range(0f, 100f)]
    public float dropChance = 0f; //  % chance to drop a power-up on death.

    public void SpawnPowerup(Transform deadEnemy)
    {

        float number = Random.Range(0f, 100f);
        if(!(number <= dropChance))
        {
            return; // RNG says no drop this time!
        }
        //Here we determine WHAT powerup will spawn.
        int choose_power = Random.Range(0, Constants.MAX + 1); //For ints, random.range is incluse, exclusive - thus we need a a + 1.
        switch (choose_power)
        {
            case 0:

                Instantiate(SHOTSPEED_POWERUP, deadEnemy.position, deadEnemy.rotation);
                break;
            case 1:
                Instantiate(PLAYSERSPEED_POWERUP, deadEnemy.position, deadEnemy.rotation);
                break;
        }




    }

}
    
