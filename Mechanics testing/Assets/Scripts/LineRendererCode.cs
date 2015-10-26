using UnityEngine;
using System.Collections;

public class LineRendererCode : MonoBehaviour {
	
	//Line Renderer
	public Texture mySprite;
	public Vector3 myPoint1;
	public Vector3 myPoint2;
	
	//Material
	public Material myMaterial;
	public float xScaleFactor;
	private float adjustedXSize;
	
	// Update is called once per frame
	void Update () {
		myMaterial.SetTexture(0, mySprite);
		GetComponent<LineRenderer> ().SetPosition (0, myPoint1);
		GetComponent<LineRenderer> ().SetPosition (1, myPoint2);
		adjustedXSize = xScaleFactor * (Mathf.Abs(Vector2.Distance(myPoint1, myPoint2)));
		
		myMaterial.mainTextureScale = new Vector2(adjustedXSize, myMaterial.mainTextureScale.y);
	}
}