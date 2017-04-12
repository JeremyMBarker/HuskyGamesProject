using UnityEngine;
using System.Collections;

static class Constants
{
    public const int SHOTSPEED = 0;
    public const int PLAYERSPEED = 1;
    public const int SHIELD = 2;
    public const int MAX = 2; // This is our highest static power-up value.


}


public class PowerUp : MonoBehaviour
{
    public GameObject SHOTSPEED_POWERUP;
    public GameObject PLAYSERSPEED_POWERUP;
    public GameObject SHIELD_POWERUP;
    public GameObject NEGATIVE_DROP;
    [Range(0f, 100f)]
    public float dropChance; //  % chance to drop a power-up on death.
    [Range(0f, 100f)]
    public float dropNegative; //  % chance to make power-up negative.

    public void SpawnPowerup(Transform deadEnemy)
    {

        float number = Random.Range(0f, 100f);
        if (!(number <= dropChance))
        {
            return; // RNG says no drop this time!
        }

        float isNegative = Random.Range(0f, 100f);

        if (dropNegative > isNegative)
        {
            //Making it a negative drop!
            Instantiate(NEGATIVE_DROP, deadEnemy.position, deadEnemy.rotation);
            return;
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
            case 2:
                Instantiate(SHIELD_POWERUP, deadEnemy.position, deadEnemy.rotation);
                break;
        }




    }

}

