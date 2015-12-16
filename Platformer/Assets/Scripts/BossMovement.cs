using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour {
    //X: [10, 40]
    //Y: [58, 64]
    private float waitTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > waitTime)
        {
            waitTime = Time.time + 2f;
            Vector3 newPos = new Vector3(UnityEngine.Random.Range(10, 40), UnityEngine.Random.Range(58, 64), 1);
            transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
        }
	}
}
