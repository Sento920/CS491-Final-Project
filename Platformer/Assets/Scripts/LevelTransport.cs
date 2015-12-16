using UnityEngine;
using System.Collections;

public class LevelTransport : MonoBehaviour {
	public string lvlToLoad;
    private string gameOver;
	
	void OnTriggerEnter2D(Collider2D coll) {
        gameOver = lvlToLoad;
        Application.LoadLevel(lvlToLoad);
        
	}

    public void Teleport()
    {
        Application.LoadLevel(gameOver);
    }

}
