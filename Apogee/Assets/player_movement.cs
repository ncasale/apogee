using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {

	//Player's rigidbody
	Rigidbody2D rb;

	//The speed of our player
	public float speed = 20f;

	//Jumping variables
	public float jumpSpeed = 20f;
	public bool inAir = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Do movement here
	void Update () {
		
		//Move
		float horizontalMove = Input.GetAxis ("Horizontal");
		float movement = horizontalMove * speed * Time.deltaTime;
		rb.velocity = new Vector2 (movement, rb.velocity.y);

		//Jump
		if (Input.GetKeyDown (KeyCode.Space) && !inAir) {
			rb.AddForce (new Vector2 (0f, jumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
			inAir = true;
		}
	}		
		
}
