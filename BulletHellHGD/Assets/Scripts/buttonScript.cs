using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class buttonScript : MonoBehaviour {

	public static int moving = 0;
	enum ButtonObj {Play, Options, Exit};
	float right;
	float posY;
	// Use this for initialization
	void Start () {
		
	}
	/**Changes the game scene when called.
	 * int sceneIndex - The index of the scene that will be called.
	 * 	The scene indexes can be found by checking the build manager.
	 */
	public void changeScene(int sceneIndex){
		SceneManager.LoadScene(sceneIndex);
	}

	public void exitApplicatio(){
		Application.Quit();
	}

	public void transition(){
		if(moving != 1){
			moving = 1;
		}
	}

	public void lockAspect(int level){
		switch(level){
			case 1:
			break;
		}
	}

	/**Changes the AA levels
	 * int level - the level of AA going to
	 * 0, 2, 4, and 8.
	 * */
	public void AA(int level){
		switch(level){
		case 0:	
			QualitySettings.antiAliasing = 0;
			break;
		case 1:
			QualitySettings.antiAliasing = 2;
			break;
		case 2:
			QualitySettings.antiAliasing = 4;
			break;
		case 3:
			QualitySettings.antiAliasing = 8;
			break;
		}
	}

}
