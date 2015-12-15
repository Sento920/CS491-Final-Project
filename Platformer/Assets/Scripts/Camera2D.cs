using UnityEngine;

 using System.Collections;
 
 public class Camera2D : MonoBehaviour {
     
     public float dampTime = 0.15f;
	private float horizShift;
	 public float vertShift;
     private Vector3 velocity = Vector3.zero;
     public Transform target;
	private float turnTime;

     // Update is called once per frame
     void Update () 
     {
         if (target)
         {
			if (Time.time > turnTime) {
				turnTime = Time.time + 0.75f;
				if (target.localScale.x == -1) {
					horizShift = 0.7f;
				} else {
					horizShift = 0.3f;
				}
			}
             Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(horizShift, vertShift, point.z)); //(new Vector3(0.5, 0.5, point.z));
             Vector3 destination = transform.position + delta;
             transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
         }
	}	
}