using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class obstacle_behavior : MonoBehaviour {

	//Function to restart scene if player hits obstacle
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player")
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			
	}
}
