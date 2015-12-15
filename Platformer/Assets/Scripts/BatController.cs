using UnityEngine;
using System.Collections;

public class BatController : MonoBehaviour {
    public GameObject target;
    private float currLerpTime;
	private Rigidbody2D rb2D;
    public float lerpChange;
	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
        currLerpTime = Time.deltaTime;
        float dist = Vector3.Distance(transform.position, target.transform.position);
        float t = currLerpTime / lerpChange;
        t = Mathf.Sin(t * Mathf.PI * 0.5f);
        if (Vector3.Distance(transform.position, target.transform.position) <= 15) {
			rb2D.MovePosition(Vector3.MoveTowards(transform.position, target.transform.position, t));
        }      
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.layer == LayerMask.NameToLayer("Arrow")) {
			Destroy(gameObject);
		}
	}
}
