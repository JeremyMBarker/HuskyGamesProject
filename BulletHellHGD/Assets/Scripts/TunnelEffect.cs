using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TunnelEffect : MonoBehaviour {

	#region Variables
	public Shader curShader;
	public float speed = 0.0f;

	private Material curMaterial;
	#endregion
	/**Check if object has a material. If not create a temporary material
	 * return: Material created or already in use
	* */
	#region Properties
	Material material{
		get{
			if(curMaterial == null){
				curMaterial = new Material(curShader);
				//dont save new material
				curMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return curMaterial;
		}
	}
	#endregion
	// Use this for initialization
	void Start () {
		//check if system supports image effects
		if(!SystemInfo.supportsImageEffects){
			enabled = false;
			Debug.Log("Image Effects not supported");
			return;
		}
		//check of shader is support on the graphics card
		if(!curShader && !curShader.isSupported){
			Debug.Log("GPU does not support graphics");
			enabled = false;
		}
	}

	void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture){
		if(curShader != null){
			material.SetFloat("_TunnelSpeed", speed);

			//set render target
			Graphics.Blit(sourceTexture, destTexture, material);
		}
	}
	// Update is called once per frame
	void Update () {
		speed = Mathf.Clamp(speed, 0.0f, 100.0f);

	}
	//cleanup script
	void OnDisable(){
		if(curMaterial){
			DestroyImmediate(curMaterial);
		}
	}

}
