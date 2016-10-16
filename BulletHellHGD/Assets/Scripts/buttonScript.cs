using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour {
	
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
}
