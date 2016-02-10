using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class collection_manager : MonoBehaviour {

	//List of bools indicating if certain collectibles have already been collected
	public List<bool> collectibleList = new List<bool>();

	int listSize = 4;

	void Awake(){
		
		//Load list of collectibles
		for (int i = 0; i < listSize; i++) {
			collectibleList.Add (false);
		}

		//Here we will eventually load a list, for now nothing goes in Start()
		DontDestroyOnLoad(gameObject);
	}

	void Start(){
		//If there is more than one collection manager - destroy self
		var CMArray = GameObject.FindGameObjectsWithTag("Collection Manager");
		var CMCount = CMArray.Length;
		if (CMCount > 1)
			Destroy (gameObject);
	}

	public void updateCollectibleList(int index){

		//Update list entry
		if (index >= 0 && index < listSize)
			collectibleList [index] = true;
		else
			Debug.Log ("Collectible index out of range.");
	}
		
}
