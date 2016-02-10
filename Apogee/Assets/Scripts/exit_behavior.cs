using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class exit_behavior : MonoBehaviour {

	//The index of the next level
	public int nextLevel;



	//Function to handle player exiting level
	void OnTriggerEnter2D(Collider2D other){

		//Check for player
		if (other.tag == "Player" && nextLevel < SceneManager.sceneCountInBuildSettings)
			SceneManager.LoadScene (nextLevel);
		else
			Debug.Log ("No Next Level.");
	}

}
