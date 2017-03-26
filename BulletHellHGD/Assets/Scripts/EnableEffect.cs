using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;

public class EnableEffect : MonoBehaviour {
	private GameObject cam;

	// Use this for initialization
	void Start () {
		//effects will be applied to main camera
		cam = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/**Activates the GrayScale component on the main
	 * camera. If component is already active it will
	 * only update the shader based of the parameter.
	 * @param float ramp - The magnitude of the grayscale.
	 * 		0 is no grayscale, and 1 is total grayscale.
	 *@return - On success returns 1. On failure to detect
	 *	component returns -1. Returns 0 when component is
	 *	already active.
	 * */
	public int runGrayscale(float ramp){
		GrayScale shader;
		shader = cam.GetComponent(typeof(GrayScale)) as GrayScale;
		if(shader == null){
			return -1;
		}
		//test if shader already running
		if(shader.isActiveAndEnabled){
			shader.setGrayScale(ramp);
			return 0;
		}
		else{
			shader.enabled = true;
			shader.setGrayScale(ramp);
			return 1;
		}
		return 0;
	}

	/**Activates and runs the Vignette and Chromatic Aberration shader.
	 * If the component is already active then it will be updated with
	 * the parameters. This function only includes basic functions for
	 * the shader. For a more features of the shader use getVignette()
	 * to manipulate the component directly with all its options.
	 * 
	 * @return - 1 on succesful activation.
	 * 			0 on Update.
	 * 			-1 on failure to activate or detect.
	 * */
	public int runVignette(float chromaticAberration, float blur, float blurSpread, float blurDistance, float intenisty, float axialAberration){
		VignetteAndChromaticAberration shader;
		shader = cam.GetComponent<VignetteAndChromaticAberration>();
		if(shader == null){
			return -1;
		}
		//test if shader running
		if(shader.isActiveAndEnabled){
			shader.intensity = intenisty;
			shader.axialAberration = axialAberration;
			shader.blur = blur;
			shader.blurSpread = blurSpread;
			shader.chromaticAberration = chromaticAberration;
			shader.blurDistance = blurDistance;
			return 0;
		}
		else{
			shader.enabled = true;
			shader.intensity = intenisty;
			shader.axialAberration = axialAberration;
			shader.blur = blur;
			shader.blurSpread = blurSpread;
			shader.chromaticAberration = chromaticAberration;
			shader.blurDistance = blurDistance;
			return 1;
		}
	}

	public int runSineWave(){
		return -1;
	}

	/**Gets the  VignetteAndChromaticAberration shader from
	 * the camera for direct manipulation.
	 * 
	 * @return -  VignetteAndChromaticAberration shader,
	 * 			null on failure.
	 * */
	public VignetteAndChromaticAberration getVignette(){
		VignetteAndChromaticAberration shader;
		shader = cam.GetComponent<VignetteAndChromaticAberration>();
		if(shader == null){
			return null;
		}
		else{
			return shader;
		}
	}

	/**Gets the GrayScale Component from the camera.
	 * 
	 * @return - The GrayScale component on success, null on failure.
	 * */
	public GrayScale getGrayScaleComponent(){
		GrayScale gs;
		gs = cam.GetComponent<GrayScale>();
		if(gs == null){
			return null;
		}
		else{
			return gs;	
		}
	} 

}
