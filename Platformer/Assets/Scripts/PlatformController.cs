using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
	public GameObject target;
	private bool reverse;
	private Vector3 startPos;
	private GameObject player;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null && player.transform.parent != null) {
			
		}
		if(Input.GetKeyDown(KeyCode.Space) && player != null && player.transform.parent != null) {
			player.transform.parent = null;
		}
		if (Mathf.Abs(Vector3.Distance (transform.position, target.transform.position)) <= 1 ||
		    Mathf.Abs(Vector3.Distance (transform.position, startPos)) <= 1) {
			reverse = !reverse;
		} 
		if (reverse) {
			transform.position = Vector3.Lerp (transform.position, startPos, Time.deltaTime);

		} else {

			transform.position = Vector3.Lerp (transform.position, target.transform.position, Time.deltaTime/4f);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Player")) {
				player = coll.gameObject;
			GameObject empty = new GameObject ();
			player.transform.SetParent (empty.transform);
			empty.transform.SetParent (transform);
			Destroy (GetComponent<Rigidbody2D> ());
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		player.transform.parent = null;
		if (transform.childCount != 0) {
			Destroy (transform.FindChild ("New Game Object").gameObject);
		}
	}

}
