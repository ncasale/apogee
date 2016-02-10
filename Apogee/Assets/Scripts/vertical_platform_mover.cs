using UnityEngine;
using System.Collections;

public class vertical_platform_mover : MonoBehaviour {

	enum movementDirections {down = -1, up = 1};

	//Speed of platform
	public float speed = 1f;

	//Starting position
	Vector3 startingPosition;

	//Final platform position
	public Transform end_point;
	Vector3 finalPosition;

	//Distance
	float travelDistance;
	float distCovered;
	float fracJourney;

	//Start time
	float startTime;

	//Journeying to final destination
	bool toFinal = true;

	//Initial movement direction
	public int moveDirection;

	// Use this for initialization
	void Start () {

		//Get starting position of platform
		startingPosition = transform.position;

		//Get final position
		finalPosition = end_point.transform.position;

		//Distance between start and end
		travelDistance = Vector3.Distance(startingPosition, finalPosition);

		//Set start time
		startTime = Time.time;

		//See if we are moving right or left to start
		if (finalPosition.y - startingPosition.y < 0)
			moveDirection = (int)movementDirections.down;
		else
			moveDirection = (int)movementDirections.up;

	}

	void Update(){

		distCovered = (Time.time - startTime) * speed;
		fracJourney = distCovered / travelDistance;

		if (toFinal)
			transform.position = Vector3.Lerp (startingPosition, finalPosition, fracJourney);
		else
			transform.position = Vector3.Lerp (finalPosition, startingPosition, fracJourney);

		//Check to see if we have hit end -- reset variables if we have
		if (fracJourney >= 1) {
			toFinal = !toFinal;
			startTime = Time.time;
			moveDirection *= -1;
		}
	} 
}
