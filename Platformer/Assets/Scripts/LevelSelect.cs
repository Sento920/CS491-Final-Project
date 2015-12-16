using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Application.LoadLevel("Plains");
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            Application.LoadLevel("Dungeon");
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            Application.LoadLevel("EvilLair");
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            Application.LoadLevel("FinalBoss");
        }
    }
}
