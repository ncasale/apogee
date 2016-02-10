using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class collectible_behavior : MonoBehaviour {

	//The index of the collectible in collectible array
	public int index;

	//The collection manager
	public collection_manager collectionManager;

	//List of collectibles
	List<bool> collectibleList;

	void Start()	{

		//Get Collectible List
		collectibleList = collectionManager.GetComponent<collection_manager> ().collectibleList;

		//If collectible has already been collected - destroy it
		if (collectibleList[index] == true)
			Destroy (gameObject);
	}

	//Function to handle player colliding with collectible
	void OnTriggerEnter2D(Collider2D other)	{
		//Check to see if colliding object is player
		if (other.tag == "Player") {
			//Add collectible to collection
			Debug.Log("Added Collectible #" + index + " to collection.");

			//Destroy collectible - don't load next time
			collectionManager.updateCollectibleList(index);
			Destroy (gameObject);

		}
	}



}
