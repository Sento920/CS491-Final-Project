using UnityEngine;
using System.Collections;

public class GrappleController : MonoBehaviour {
	private float dist;
	private Vector3 mousePos;
	private float newX;
	private float newY;
	private Rigidbody2D rb2D;
	private LineRendererCode lrc;
	// Use this for initialization
	void Start () {
//		GetComponentInChildren<LineRendererCode>().myPoint1 = transform.position;
		rb2D = GetComponent<Rigidbody2D> ();
		lrc = GetComponentInChildren<LineRendererCode> ();
	}
	
	// Update is called once per frame
	void Update () {

//		lrc.myPoint2 = Vector2.Lerp(mousePos, transform.position, dist);
				lrc.myPoint2 = Vector2.Lerp(transform.position, mousePos, dist);
		transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);
		if (Input.GetMouseButton (0)) {

			dist = Vector3.Distance (transform.position, mousePos);

//			GetComponent<DistanceJoint2D> ().enabled = true;
			mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = 0f;


			GetComponent<DistanceJoint2D> ().connectedAnchor = mousePos;
			lrc.myPoint1 = transform.position;


//			print (Vector3.Distance(transform.position, mousePos));
		} else {
//			GetComponent<DistanceJoint2D> ().enabled = false;
		}
	}
}
