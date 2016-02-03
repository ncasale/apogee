using UnityEngine;
using System.Collections;

public class ground_check : MonoBehaviour {

	//The player
	GameObject player;

	//The speed of a moving platform
	float movingPlatformSpeed;

	//The direction of the moving platform
	int movingPlatformDirection;

	//If the platform is moving right or left

	void Start(){
		
		//Find the player
		player = GameObject.Find("player");

	}


	//Check to see if we have collided with the ground
	void OnTriggerEnter2D(Collider2D other){

		//Check to see if we have landed on a platform
		if (other.gameObject.layer == 8){ 
			player.GetComponent<player_movement> ().inAir = false;

			Debug.Log ("Tag of platform: " + other.tag);
		}

	}

	//Check to see if on moving platform and 'stick' player to it
	void OnTriggerStay2D(Collider2D other){

		if (other.tag == "Moving Platform") {

			Debug.Log ("Standing on moving platform");

			movingPlatformSpeed = other.GetComponent<platform_mover> ().speed;
			movingPlatformDirection = other.GetComponent<platform_mover> ().moveDirection;

			Debug.Log ("Move Direction: " + movingPlatformDirection);

			player.transform.position = new Vector3(player.transform.position.x + (movingPlatformSpeed * movingPlatformDirection * Time.deltaTime),
				player.transform.position.y, player.transform.position.z);
		}
			
	}
}
