using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {
	private Rigidbody2D rb2D;
	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb2D) {
			transform.right = rb2D.velocity;
		}
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x >= 1 || viewPos.x <= 0) {
            if (transform.parent != null) {
                Destroy(gameObject.transform.parent.gameObject);
            } else {
                Destroy(gameObject);
            }
        }
	}

	void OnCollisionEnter2D(Collision2D coll) {
		GameObject empty = new GameObject ();
		empty.transform.SetParent (coll.transform);
		transform.SetParent (empty.transform);
		Destroy (GetComponent<Rigidbody2D> ());
	}
}
