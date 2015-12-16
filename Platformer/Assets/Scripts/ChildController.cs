using UnityEngine;
using System.Collections;

public class ChildController : MonoBehaviour {

    public GameObject projectile;
    public Transform player;
    public Transform center;
    private Vector3 axis = new Vector3(0,0,1);
    private Vector3 desiredPosition;
    private float radius = 3.5f;
    public float radiusSpeed;
    public float rotationSpeed;
    private float waitTime;

    void Start()
    {
        
        transform.position = (transform.position - center.position).normalized * radius + center.position;

    }

    void Update()
    {
        if(Time.time > waitTime)
        {
            radius = UnityEngine.Random.Range(3.5f, 6f);
            waitTime = Time.time + 2f;
            //float angle = Mathf.Atan2(player.position.x - transform.position.x, player.position.y - transform.position.y);
            float angle = Mathf.Atan2(transform.position.x - player.position.x, transform.position.y - player.position.y);

            print(angle);
            Instantiate(projectile, transform.position, Quaternion.LookRotation(player.position));
            projectile.GetComponent<Rigidbody2D>().velocity = (player.position - transform.position).normalized * 10;
        }

        transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
        desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
        transform.rotation = Quaternion.identity;
    }
}
