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
	private SpringJoint2D sj2D;
	public Transform parent;
	private Vector3 parentPos;
	private bool fired;
	private bool grappleHit;
	// Use this for initialization
	void Start ()
	{
//		GetComponentInChildren<LineRendererCode>().myPoint1 = transform.position;
		parentPos = parent.position;
		lrc = GetComponentInChildren<LineRendererCode> ();
		lrc.myPoint1 = parentPos;
		rb2D = GetComponent<Rigidbody2D> ();
		sj2D = GetComponentInParent<SpringJoint2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		print (transform.up);
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
			GetComponent<SpriteRenderer>().enabled = true;
			rb2D.AddForce (transform.up * 1000);
		} 
		if (grappleHit) {
			sj2D.distance -= Input.GetAxis("Vertical")/4f;
		}
		if (Input.GetKeyDown (KeyCode.LeftShift) && grappleHit) {
			sj2D.enabled = false;
			GetComponent<SpriteRenderer>().enabled = false;
			rb2D.constraints = RigidbodyConstraints2D.None;
			grappleHit = false;
			fired = false;
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		grappleHit = true;
		hitPos = coll.contacts [0].point;
		transform.position = hitPos;
		rb2D.constraints = RigidbodyConstraints2D.FreezePosition;
		sj2D.connectedAnchor = hitPos;
		sj2D.distance = dist;
		sj2D.enabled = true;
	}
}
