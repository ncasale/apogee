using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour {

	//Player's rigidbody
	Rigidbody2D rb;

	//Movement Variables
	public float speed = 20f;
	public float horizontalMove;
	public float movement;


	//Jumping variables
	public float jumpSpeed = 20f;
	public bool inAir = false;

	//Wall Collision Variables
	public Transform topWallCollide;
	public Transform bottomWallCollide;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update(){

		//Move
		horizontalMove = Input.GetAxis ("Horizontal");
		movement = horizontalMove * speed * Time.deltaTime;
		rb.velocity = new Vector2 (movement, rb.velocity.y);



		//Jump
		if (Input.GetKeyDown (KeyCode.Space) && !inAir) {
			rb.AddForce (new Vector2 (0f, jumpSpeed), ForceMode2D.Impulse);
			inAir = true;
		}

		//Restart level
		if (Input.GetKeyDown (KeyCode.R))
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

		//Quit game
		if (Input.GetKeyDown (KeyCode.K))
			Application.Quit();
	}
		
			
}