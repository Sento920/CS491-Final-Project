using UnityEngine;
using System.Collections;

public class LevelTransport : MonoBehaviour {
	public string lvlToLoad;
	
	void OnTriggerEnter2D(Collider2D coll) {
		Application.LoadLevel(lvlToLoad);
	}
}
