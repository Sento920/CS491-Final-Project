using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb2D;
	private Animator animator;
	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float push = Input.GetAxis ("Horizontal");
		if (push != 0) {
			rb2D.velocity=(new Vector2(push * 5, 0));
			animator.SetBool("isGrounded", true);
			if (push < 0) {
				transform.localScale = new Vector2(-1,1);
			} else {
				transform.localScale = new Vector2(1,1);
			}
		} else {
			animator.SetBool("isGrounded", false);
		}
	}
}
