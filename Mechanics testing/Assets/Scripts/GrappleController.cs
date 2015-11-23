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
	private Vector3 playerPos;
	private bool fired;
	private bool grappleHit;
	public float grappleMaxDist;
	private Vector3 mousePos;
	// Use this for initialization
	void Start ()
	{
		//		GetComponentInChildren<LineRendererCode>().myPoint1 = transform.position;
		playerPos = parent.position;
		lrc = GetComponentInChildren<LineRendererCode> ();
		lrc.enabled = false;
		lrc.myPoint1 = playerPos;
		rb2D = GetComponent<Rigidbody2D> ();
		sj2D = GetComponentInParent<SpringJoint2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		playerPos = parent.position;
		
		
		lrc.myPoint1 = playerPos;
		lrc.myPoint2 = transform.position;

		if (!fired) {
			mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = 0f;
			transform.position = playerPos;
			transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);
		}

		//fire grapple
		if (Input.GetMouseButtonDown(0) && !fired) {
			fired = true;
			lrc.enabled = true;
			GetComponentInChildren<LineRenderer> ().enabled = true;
			GetComponent<SpriteRenderer>().enabled = true;
			rb2D.AddForce (transform.up * 1500);
		} 

		if (Vector3.Distance (playerPos, transform.position) >= grappleMaxDist) {
			print (rb2D.velocity);
			rb2D.velocity = Vector2.zero;
			ResetGrapple();
		}
//		if (fired) {
//			sj2D.enabled = true;
//			sj2D.distance = Mathf.Clamp(sj2D.distance + 0.1f, 0, grappleMaxDist);
//		}
		//move up/down rope
		if (grappleHit) {
			sj2D.distance = Mathf.Clamp(sj2D.distance - Input.GetAxis("Vertical")/4f, 0, grappleMaxDist);
		}
		//release grapple
		if (Input.GetMouseButtonDown(0) && grappleHit) {
			ResetGrapple();
		}
	}

	void ResetGrapple() {
		sj2D.enabled = false;
		lrc.enabled = true;
		GetComponentInChildren<LineRenderer> ().enabled = false;
		GetComponent<SpriteRenderer>().enabled = false;
		rb2D.constraints = RigidbodyConstraints2D.None;
		grappleHit = false;
		fired = false;
	}
	
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "grapplePoint") {
			grappleHit = true;
			hitPos = coll.contacts [0].point;
			dist = Vector3.Distance (playerPos, hitPos);
			transform.position = hitPos;
			rb2D.transform.rotation = Quaternion.identity;
			rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
			sj2D.connectedAnchor = hitPos;
			sj2D.distance = dist;
			sj2D.enabled = true;
		} else {
			ResetGrapple();
		}
	}
}