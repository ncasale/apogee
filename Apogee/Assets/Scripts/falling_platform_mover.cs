using UnityEngine;
using System.Collections;

public class falling_platform_mover : MonoBehaviour {

	//Flag indicating that platform is currently in the process of falling
	bool isFalling = false;

	//Starting position of platform
	Vector2 starting_position;

	// Use this for initialization
	void Start () {

		//Get starting position
		starting_position = transform.position;
	
	}

	//Coroutine to collapse platform
	public IEnumerator Fall(){

		Debug.Log ("Start Falling Process.");
		//Wait one second before falling
		yield return new WaitForSeconds (1f);

		//Turn off kinematic and turn on gravity
		GetComponent<Rigidbody2D>().isKinematic = false;
		GetComponent<Rigidbody2D> ().gravityScale = 0.5f;
	}

	//Coroutine to respawn platform
	public IEnumerator Respawn(){
		//Wait for 2 seconds
		yield return new WaitForSeconds(2f);

		//Reactivate platform back at starting position
		transform.position = starting_position;
		ReEnablePlatform ();

	}

	void OnCollisionEnter2D(Collision2D other){

		Debug.Log ("Falling Platform collision detected.");

		//If player hits platform, cause it to fall
		if (other.gameObject.tag == "Player" && !isFalling) {
			Debug.Log ("Player has landed on falling platform");
			isFalling = true;
			StartCoroutine ("Fall");
		}
		else if(other.gameObject.tag == "Player" && isFalling)
			return;
		else if(isFalling){
			//If falling platform hits something deactivate it and start respawn process
			DisablePlatform();
			StartCoroutine ("Respawn");
		}
			
	}

	void DisablePlatform(){
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<PolygonCollider2D> ().enabled = false;
		GetComponent<Rigidbody2D> ().isKinematic = true;
	}

	void ReEnablePlatform(){
		GetComponent<SpriteRenderer> ().enabled = true;
		GetComponent<PolygonCollider2D> ().enabled = true;
		isFalling = false;
	}
}
