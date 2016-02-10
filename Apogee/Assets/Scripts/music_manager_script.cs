using UnityEngine;
using System.Collections;

public class music_manager_script : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//Check to see if other music managers exist, if so, don't load
		var MMArray = GameObject.FindGameObjectsWithTag("Music Manager");
		var MMCount = MMArray.Length;

		if (MMCount > 1)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
	}
}
