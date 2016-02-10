using UnityEngine;
using System.Collections;

public class nova_behavior : MonoBehaviour {

	//Is Nova currently being displayed?
	bool isActive = true;

	//Player Variables -- player is parent object
	Rigidbody2D playerBody;
	Vector2 playerVelocity;
	float playerMovementDirection;

	//Nova's distance from player
	float distanceFromPlayer = 0.25f;


	// Use this for initialization
	void Start () {

		//Get Rigidbody2D of player
		playerBody = GetComponentInParent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {

		//Find the player's velocity
		playerVelocity = playerBody.velocity;

		//Find player's movement direction
		playerMovementDirection = GetComponentInParent<player_movement>().horizontalMove;

		//If we are not moving show Nova
		if (playerVelocity == new Vector2 (0f, 0f) && !isActive) {
			ActivateNova ();
		}

		//If we are moving, don't show nova
		if (playerVelocity != new Vector2 (0f, 0f) && isActive) {
			DeactivateNova ();
		}

		//Change Nova direction
		OrientNova(playerMovementDirection);
	
	}	

	void ActivateNova(){

		Debug.Log ("Activating Nova");

		//Set flag
		isActive = true;

		//Activate Sprite Renderer
		GetComponent<SpriteRenderer> ().enabled = true;

		//Turn off particle emitter
		ParticleSystem.EmissionModule ema = GetComponent<ParticleSystem>().emission;
		ema.enabled = false;
		GetComponent<ParticleSystem> ().Clear ();

	}

	void DeactivateNova(){

		Debug.Log ("Deactivating Nova");

		//Set flag
		isActive = false;

		//Deactivate Sprite Renderer
		GetComponent<SpriteRenderer>().enabled = false;

		//Activate the particle system
		ParticleSystem.EmissionModule emd = GetComponent<ParticleSystem>().emission;
		emd.enabled = true;
	}

	void OrientNova(float playerMovementDirection){

		//Put Nova on right if player is moving left
		if (playerMovementDirection < 0) {
			transform.localPosition = new Vector2(distanceFromPlayer, transform.localPosition.y);
		}

		//Put Nova on left if player is moving right
		if (playerMovementDirection > 0) {
			transform.localPosition = new Vector2 (-1 * distanceFromPlayer, transform.localPosition.y);
		}
	}
}
