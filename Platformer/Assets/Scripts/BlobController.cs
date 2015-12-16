using UnityEngine;
using System.Collections;

public class BlobController : MonoBehaviour {
	private Vector2 startPos;
	public float dist;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float point = Mathf.PingPong (Time.time, 1);
		transform.position = Vector3.Lerp (startPos, new Vector2 (startPos.x + dist, startPos.y), point);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.layer == LayerMask.NameToLayer("Arrow")) {
			Destroy(gameObject);
		}
	}
}
