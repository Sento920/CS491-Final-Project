using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	public float XScale;
	public float YScale;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<Renderer>().material.mainTextureScale = new Vector2(XScale , YScale );

	}
}
