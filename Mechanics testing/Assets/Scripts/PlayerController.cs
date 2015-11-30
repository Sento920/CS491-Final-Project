﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb2D;
	public GameObject aimBar;
	private PowerBar powerBar;
	public GameObject arrow;
	private Animator animator;
	private MouseAim mouseAim;
	private bool isGrounded;
	private bool direction;
	// Use this for initialization
	void Start ()
	{
		powerBar = GetComponentInChildren<PowerBar> ();
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		mouseAim = GetComponentInChildren<MouseAim> ();
		isGrounded = true;
		direction = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float push = Input.GetAxis ("Horizontal");
		if (isGrounded && push != 0) {
			rb2D.velocity = (new Vector2 (push * 5, 0));
			animator.SetBool ("isGrounded", true);
			animator.SetBool ("Walk", true);
			if (push < 0) {
				direction = false;
				mouseAim.dir = false;
			} else {
				direction = true;
				mouseAim.dir = true;
			}
		} else {
			animator.SetBool ("Walk", false);
		}

		if (direction) {
			transform.localScale = new Vector2 (1, 1);
		} else {
			transform.localScale = new Vector2 (-1, 1);
		}

		if (Input.GetMouseButtonUp(1)) {
			print (powerBar.power);
			GameObject tmp = Instantiate(arrow, transform.position, aimBar.transform.localRotation) as GameObject;
			tmp.GetComponent<Rigidbody2D>().AddForce(aimBar.transform.right * powerBar.power * 800);
		}
	}
}
