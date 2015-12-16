using UnityEngine;
using System.Collections;

public class ChildController : MonoBehaviour {

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
        }

        transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
        desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
        transform.rotation = Quaternion.identity;
    }
}
