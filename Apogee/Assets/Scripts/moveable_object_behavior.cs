using UnityEngine;
using System.Collections;

public class moveable_object_behavior : MonoBehaviour {

	//Flag indicating that object is currently being grabbed by player
	bool grabbed = false;

	//Player Rigidbody
	Rigidbody2D playerBody;

	//Frame count
	int frameCount;
	int frameGrabbed;
	int frameUngrabbed;



	void Start(){
		//Get Player rigidbody
		GameObject player = GameObject.Find("player");
		playerBody = player.GetComponent<Rigidbody2D> ();
	}

	void Update(){

		if(grabbed) {	
			
			//Ungrab object and restrict movement
			if (Input.GetKeyDown (KeyCode.E) && frameCount != frameGrabbed) {
				gameObject.transform.parent = null;
				gameObject.layer = 10;
				grabbed = false;
				Debug.Log ("Ungrabbed Object");

			}


		}

		//Increment frame count
		frameCount += 1;
	}

	void OnCollisionStay2D(Collision2D other){

		//Allow player to grab/let go of object if E is pressed while touching it
		if (other.gameObject.tag == "Player" && Input.GetKeyDown (KeyCode.E)) {

			Debug.Log ("Grabbed Object");
			grabbed = !grabbed;
			frameGrabbed = frameCount;

			//Make box child of player
			gameObject.transform.parent = other.transform;

			//Set layer of object to Grabbed Object so player doesn't collide with it until dropped
			gameObject.layer = 11;

		}

		/*//Move with moving platforms
		if (other.gameObject.tag == "Horizontal Moving Platform") {
			//Get speed of platform
			Debug.Log("Box on horizontal moving platform");
			var speed = other.gameObject.GetComponent<horizontal_platform_mover>().speed;
			var direction = other.gameObject.GetComponent<horizontal_platform_mover> ().moveDirection;
			Debug.Log ("Speed = " + speed + " Direction = " + direction);
			transform.position = new Vector3 (transform.position.x + (speed * direction * Time.deltaTime), transform.position.y, transform.position.z);
		}*/

	}
		
}
