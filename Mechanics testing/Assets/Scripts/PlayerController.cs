using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private float dist;
	private Vector3 mousePos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float input = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (input * 5, 0f));

		if (Input.GetMouseButton (0)) {
			GetComponent<DistanceJoint2D> ().enabled = true;
			mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = 0f;
			GetComponent<DistanceJoint2D> ().connectedAnchor = mousePos;
			dist = Vector3.Distance (transform.position, mousePos);
			GetComponentInChildren<LineRendererCode>().myPoint1 = transform.position;
			GetComponentInChildren<LineRendererCode>().myPoint2 = mousePos;
//			print (Vector3.Distance(transform.position, mousePos));
		} else {
			GetComponent<DistanceJoint2D> ().enabled = false;
		}
	}

}
