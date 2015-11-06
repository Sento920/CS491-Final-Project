using UnityEngine;
using System.Collections;

public class GrappleController : MonoBehaviour
{
	private float dist;
	private Vector3 hitPos;
	private float newX;
	private float newY;
	private Rigidbody2D rb2D;
	private LineRendererCode lrc;
	private DistanceJoint2D dj2D;
	public Transform parent;
	private Vector3 parentPos;
	private bool fired;
	// Use this for initialization
	void Start ()
	{
//		GetComponentInChildren<LineRendererCode>().myPoint1 = transform.position;
		parentPos = parent.position;
		lrc = GetComponentInChildren<LineRendererCode> ();
		lrc.myPoint1 = parentPos;
		rb2D = GetComponent<Rigidbody2D> ();
		dj2D = GetComponentInParent<DistanceJoint2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		parentPos = parent.position;

		dist = Vector3.Distance (parentPos, hitPos);
		lrc.myPoint1 = parentPos;
		lrc.myPoint2 = transform.position;
		if (!fired) {
			hitPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			hitPos.z = 0f;
			transform.position = parentPos;
			transform.rotation = Quaternion.LookRotation (Vector3.forward, hitPos - transform.position);
		}

		if (Input.GetKeyDown (KeyCode.Space) && !fired) {
			fired = true;
			rb2D.AddForce (transform.up * 1000);
		}
		if (fired) {
			dj2D.distance -= Input.GetAxis("Vertical")/2f;
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		hitPos = coll.contacts [0].point;
		transform.position = hitPos;
		rb2D.constraints = RigidbodyConstraints2D.FreezePosition;
		dj2D.connectedAnchor = hitPos;
		dj2D.enabled = true;
		dj2D.distance = dist;
	}
}
