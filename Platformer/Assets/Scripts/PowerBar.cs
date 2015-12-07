using UnityEngine;
using System.Collections;

public class PowerBar : MonoBehaviour
{
	public float maxHealth;
	public float health;
	public float power;
	private float chargeTime;
	// Use this for initialization
	void Start ()
	{
		chargeTime = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (1)) {
			chargeTime+= 0.05f;
			health = Mathf.Abs (Mathf.Sin (chargeTime));
			power = transform.localScale.x;
		} else {
			chargeTime = 0;
			health = 0;
		}
		transform.localScale = new Vector3 ((health * 100)/maxHealth, 1, 1);

	}
}
