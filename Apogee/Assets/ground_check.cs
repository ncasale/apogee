using UnityEngine;
using System.Collections;

public class ground_check : MonoBehaviour {

	//The player
	GameObject player;

	void Start(){
		
		//Find the player
		player = GameObject.Find("player");

	}


	//Check to see if we have collided with the ground
	void OnTriggerEnter2D(Collider2D other){

		//Check to see if we have hit the ground
		if (other.tag == "Platform") {
			player.GetComponent<player_movement> ().inAir = false;
		}
	}
}
