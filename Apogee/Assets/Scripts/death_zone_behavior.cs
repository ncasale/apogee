using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class death_zone_behavior : MonoBehaviour {

	//If player enters death zone, restart level
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player")
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
