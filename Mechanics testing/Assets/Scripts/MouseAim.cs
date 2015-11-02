using UnityEngine;
using System.Collections;

public class MouseAim : MonoBehaviour {
	private Vector3 mousePos;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		float angle = Mathf.Atan2 (mousePos.y-transform.position.y, mousePos.x-transform.position.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);	
	}
}
