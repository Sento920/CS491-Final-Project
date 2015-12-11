using UnityEngine;
using System.Collections;

public class BlockMaterialFix : MonoBehaviour {

    private Material instancedMaterial;
	// Use this for initialization
	void Start () {
        instancedMaterial = new Material(GetComponent<Renderer>().material);
        instancedMaterial.mainTextureScale = new Vector2(-transform.localScale.x, -transform.localScale.y);
        GetComponent<Renderer>().material = instancedMaterial;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
