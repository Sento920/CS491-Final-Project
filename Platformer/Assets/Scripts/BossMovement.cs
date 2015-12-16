using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour {
    //X: [10, 40]
    //Y: [58, 64]
    private ChildController childController;
    public GameObject projectile;
    public GameObject player;
    private Vector3 playerPos;
    private float waitTime;
    private float bossWait;
    private int numHits;
	// Use this for initialization
	void Start () {
        childController = GetComponent<ChildController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > waitTime)
        {
            waitTime = Time.time + 2f;
            Vector3 newPos = new Vector3(UnityEngine.Random.Range(10, 40), UnityEngine.Random.Range(58, 64), 1);
            transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
        }
        if (childController.getChildCount() == 0)
        {
            if (Time.time > bossWait)
            {
                print("child count = 0");
                bossWait = Time.time + 1f;
                {
                    print("firing");
                    playerPos = player.transform.position;
                   
                        float angle = Mathf.Atan2(transform.position.y - playerPos.y, transform.position.x - playerPos.x) * Mathf.Rad2Deg;

                        GameObject tmp = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
                        tmp.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                        tmp.GetComponent<Rigidbody2D>().velocity = (playerPos - transform.position).normalized * 20;
                        
                    
                }
            }
        }
	}
    void OnCollisionEnter2D(Collision2D coll)
    {

        numHits++;
        if (numHits >= 3)
        {
            Application.LoadLevel("Win");
        }
    }
}
