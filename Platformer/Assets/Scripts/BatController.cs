using UnityEngine;
using System.Collections;

public class BatController : MonoBehaviour {
    public GameObject target;
    private float currLerpTime;
    public float lerpChange;
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        currLerpTime = Time.deltaTime;
        print(Vector3.Distance(transform.position, target.transform.position));
        float dist = Vector3.Distance(transform.position, target.transform.position);
        float t = currLerpTime / lerpChange;
        t = Mathf.Sin(t * Mathf.PI * 0.5f);
        if (Vector3.Distance(transform.position, target.transform.position) <= 15) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, t);
        }
    
        //transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime);

       
	}
}
