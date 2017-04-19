using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDown : MonoBehaviour {
    private int numEffects = 2;
    public float grayscaleRamp;
    public float waitTime;


    public void runNegEffect()
    {
            StartCoroutine(spawnPowerDown());
    }


        IEnumerator spawnPowerDown()
    {
        int n = Random.Range(0, numEffects);
        var effects = GetComponent<EnableEffect>();

        switch (n)
        {
            case 0:
                effects.runGrayscale(grayscaleRamp);
                yield return new WaitForSeconds(waitTime);
                effects.runGrayscale(0);
                break;
            case 1:
                effects.runVignette(.5f, .75f, .5f, .5f, .75f, .45f);
                yield return new WaitForSeconds(waitTime);
                effects.runVignette(0, 0, 0, 0, 0, 0);
                break;

        }
        yield return new WaitForSeconds(0);
    }
}
