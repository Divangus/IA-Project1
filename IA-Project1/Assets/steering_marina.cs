using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class steering_marina : MonoBehaviour
{
    public GameObject agent;
    public GameObject target1;
    public float maxSpeed, maxTurnSpeed;
    public float movSpeed, turnSpeed, acceleration, turnAcceleration;
    public float stopDistance;
    public Vector3 movement;
    public Quaternion rotation;
    //int ds = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target1.transform.position, transform.position) < stopDistance) {
            return;
        }
        Seek(target1); 
    

        turnSpeed += turnAcceleration * Time.deltaTime;
        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
        movSpeed += acceleration * Time.deltaTime;
        movSpeed = Mathf.Min(movSpeed, maxSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                              rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * movSpeed *
                              Time.deltaTime;

    }

    void Seek(GameObject target)
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;
        movement = direction.normalized * acceleration;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
 
}
