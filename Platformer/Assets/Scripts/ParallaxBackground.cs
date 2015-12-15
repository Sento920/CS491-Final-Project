using UnityEngine;
using System.Collections;

public class ParallaxBackground : MonoBehaviour {
    public float lvlEdgeToCameraEdge;
    public float BGEdgeToCameraEdge;
    private Vector3 startPos;
    private Vector3 bgStartPos;
    private float bgShift;
	// Use this for initialization
	void Start () {
        bgShift = BGEdgeToCameraEdge / lvlEdgeToCameraEdge;
        startPos = Camera.main.transform.position;
        bgStartPos = transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {
        float distMovedX = Mathf.Abs(Camera.main.transform.position.x - startPos.x);
        float distMovedY = Mathf.Abs(Camera.main.transform.position.y - startPos.y);
        float bgMoveX = (distMovedX * bgShift);
        float bgMoveY = (distMovedY * bgShift);

        Vector3 newPos = new Vector3(Camera.main.transform.position.x + bgMoveX - (startPos.x - bgStartPos.x), Camera.main.transform.position.y + bgMoveY - (startPos.y - bgStartPos.y), transform.position.z);
        transform.position = newPos;
    }
}
