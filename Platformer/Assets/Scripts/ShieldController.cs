using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour {
    public ChildController children;
    private int childNum;
    private SpriteRenderer spriteRend;
	// Use this for initialization
	void Start () {
        //childNum = children.getChildCount();
        spriteRend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        childNum = children.getChildCount();
        spriteRend.color = new Color(spriteRend.color.r, spriteRend.color.g, spriteRend.color.b, 255f * (childNum / 7f));
        print(spriteRend.color.a);
        if(childNum == 0)
        {
            Destroy(gameObject);
        }
    }
}
