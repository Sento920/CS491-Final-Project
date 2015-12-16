using UnityEngine;
using System.Collections;

public class BlobController : MonoBehaviour {
	private Vector2 startPos;
    private Rigidbody2D rb2d;
	public float dist;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        startPos = rb2d.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		float point = Mathf.PingPong (Time.time, 1);
		rb2d.MovePosition( Vector3.Lerp (startPos, new Vector2 (startPos.x + dist, rb2d.position.y), point));
        
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.layer == LayerMask.NameToLayer("Arrow")) {
			Destroy(gameObject);
		}
	}
}
