using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb2D;
	private Animator animator;
	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		animator.SetBool("isGrounded", true);

	}
	
	// Update is called once per frame
	void Update () {
		float push = Input.GetAxis ("Horizontal");
		if (push != 0) {
			rb2D.velocity=(new Vector2(push * 5, 0));
			if (push < 0) {
				animator.SetInteger("WalkDir", -1);
			} else {
				animator.SetInteger("WalkDir", 1);
			}
		} else {
			animator.SetInteger("WalkDir", 0);
		}
	}
}
