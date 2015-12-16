using UnityEngine;
using System.Collections;

public class ChildController : MonoBehaviour {
    public GameObject player;
    public GameObject projectile;
    public GameObject[] childEyes;
    public float waitTime;
    private Vector3 playerPos;
    private GameObject eyeToFire;
    private float closestDist;
    // Use this for initialization
    void Start () {
        closestDist = Vector2.Distance(player.transform.position, childEyes[0].transform.position);
        eyeToFire = childEyes[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > waitTime)
        {
            playerPos = player.transform.position;
            waitTime = Time.time + 2f;
            for (int i = 0; i < childEyes.Length; i++)
            {
                if(childEyes[i] != null)
                {
                    closestDist = Vector2.Distance(player.transform.position, childEyes[i].transform.position);
                    print("closest dist check " + i);
                    break;
                }
            }
                for (int i = 0; i < childEyes.Length; i++)
            {
                //check dist b/w child eye and player
                //only closest one fires
                if (childEyes[i] != null) {
                    float dist = Vector2.Distance(player.transform.position, childEyes[i].transform.position);
                    print(childEyes[i].name + " dist " + dist + " closest dist " + closestDist);
                    if (dist <= closestDist)
                    {
                        closestDist = dist;
                        eyeToFire = childEyes[i];
                    }
                }
            }
            print(eyeToFire.name);
            if (eyeToFire != null)
            {
                float angle = Mathf.Atan2(eyeToFire.transform.position.y - playerPos.y, eyeToFire.transform.position.x - playerPos.x) * Mathf.Rad2Deg;
                GameObject tmp = Instantiate(projectile, eyeToFire.transform.position, Quaternion.identity) as GameObject;
                tmp.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                tmp.GetComponent<Rigidbody2D>().velocity = (playerPos - eyeToFire.transform.position).normalized * 20;
            }
        }
    }
}
