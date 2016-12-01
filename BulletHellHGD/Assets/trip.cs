using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class trip : MonoBehaviour {

	private VignetteAndChromaticAberration chromatic_Vignette;
	private bool tripping = false;
	// Use this for initialization
	void Start () {
		chromatic_Vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
		chromatic_Vignette.blur = 0f;
		chromatic_Vignette.blurDistance = 0f;
		chromatic_Vignette.intensity = 0f;
		chromatic_Vignette.chromaticAberration = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		//toggles tripping effect. Temporary until ingame trigger is defined
		if(Input.GetKeyDown(KeyCode.T)){
			tripping = !tripping;
		}


		//sets the effects of the hallucination
		if(tripping){
			chromatic_Vignette.blur = .35f;
			chromatic_Vignette.blurDistance = 0.5f;
			chromatic_Vignette.intensity = 0.415f;
			chromatic_Vignette.chromaticAberration = Mathf.PingPong(Time.time, 2) * -100;
		}
		//removes tripping effect.
		else{
			chromatic_Vignette.blur = 0f;
			chromatic_Vignette.blurDistance = 0f;
			chromatic_Vignette.intensity = 0f;
			chromatic_Vignette.chromaticAberration = 0f;
		}

	}

	public bool isTripping(){
		return tripping;
	}	
}
