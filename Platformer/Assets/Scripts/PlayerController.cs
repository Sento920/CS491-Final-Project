using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public bool isGrounded;
    public float timeBetweenShots;
    public GameObject arrow;
    public GameObject arrowAim;
    public LayerMask layerMask;
    public Transform groundCheck;
    private Animator animator;
    public bool direction;
    private float nextFire;
    private GrappleController grapple;
    private MouseAim mouseAim;
    private PowerBar powerBar;
    private Rigidbody2D rb2D;
    
	// Use this for initialization
	void Start ()
	{
		powerBar = GetComponentInChildren<PowerBar> ();
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		mouseAim = GetComponentInChildren<MouseAim> ();
        grapple = GetComponentInChildren<GrappleController>();
		isGrounded = true;
		direction = (transform.localScale.x == 1);
	}
	
	// Update is called once per frame
	void Update ()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15f, layerMask);
		float push = Input.GetAxis ("Horizontal");
		if (!grapple.grappleHit && push != 0) {
			rb2D.velocity = (new Vector2 (push * 5, rb2D.velocity.y));
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

		//change direction for walking
		if (isGrounded) {
			if(Input.GetButtonDown("Jump")) {
				rb2D.velocity = new Vector2(rb2D.velocity.x, 6f);
			}
            if (!grapple.fired) {
                if (direction) {
                    transform.localScale = new Vector2(1, 1);
                } else {
                    transform.localScale = new Vector2(-1, 1);
                }
            }
		}

		//fire arrow
        if (Time.time > nextFire) {
            if (Input.GetMouseButtonUp(1)) {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				float angle =-Mathf.Atan2 (transform.position.y - mousePos.y, transform.position.x - mousePos.x) * Mathf.Rad2Deg;
                GameObject tmp = Instantiate(arrow, transform.position, Quaternion.AngleAxis(angle, mousePos)) as GameObject;
                tmp.GetComponent<Rigidbody2D>().AddForce(arrowAim.transform.right * powerBar.power * 800);
                nextFire = Time.time + timeBetweenShots;
            } 
			powerBar.enabled = true;

        } else {
            powerBar.enabled = false;
        }
	}
}
