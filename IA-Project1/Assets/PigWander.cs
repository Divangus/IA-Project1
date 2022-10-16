using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigWander : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target1, target2, target3, target4, target5, target6;
    public float maxVelocity = 6;
    public float slowDistance = 4;
    public float stopDistance = 2;

    public float turnSpeed = 7;
    public float turnAcceleration = 2;
    public float maxTurnSpeed = 7;
    public float movSpeed = 5;
    public float acceleration = 2;
    int choose = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction1 = target1.transform.position - transform.position;
        direction1.y = 0f;   
        Vector3 direction2 = target2.transform.position - transform.position;
        direction2.y = 0f; 
        Vector3 direction3 = target3.transform.position - transform.position;
        direction3.y = 0f;
        Vector3 direction4 = target4.transform.position - transform.position;
        direction4.y = 0f;
        Vector3 direction5 = target5.transform.position - transform.position;
        direction5.y = 0f;
        Vector3 direction6 = target6.transform.position - transform.position;
        direction6.y = 0f; 

        Vector3 movement1 = direction1.normalized * maxVelocity;
        Vector3 movement2 = direction2.normalized * maxVelocity;
        Vector3 movement3 = direction3.normalized * maxVelocity;
        Vector3 movement4 = direction4.normalized * maxVelocity;
        Vector3 movement5 = direction5.normalized * maxVelocity;
        Vector3 movement6 = direction6.normalized * maxVelocity;

        float angle1 = Mathf.Rad2Deg * Mathf.Atan2(movement1.x, movement1.z);
        float angle2 = Mathf.Rad2Deg * Mathf.Atan2(movement2.x, movement2.z);
        float angle3 = Mathf.Rad2Deg * Mathf.Atan2(movement3.x, movement3.z);
        float angle4 = Mathf.Rad2Deg * Mathf.Atan2(movement4.x, movement4.z);
        float angle5 = Mathf.Rad2Deg * Mathf.Atan2(movement5.x, movement5.z);
        float angle6 = Mathf.Rad2Deg * Mathf.Atan2(movement6.x, movement6.z);

        Quaternion rotation1 = Quaternion.AngleAxis(angle1, Vector3.up);
        Quaternion rotation2 = Quaternion.AngleAxis(angle2, Vector3.up);
        Quaternion rotation3 = Quaternion.AngleAxis(angle3, Vector3.up);
        Quaternion rotation4 = Quaternion.AngleAxis(angle4, Vector3.up);
        Quaternion rotation5 = Quaternion.AngleAxis(angle5, Vector3.up);
        Quaternion rotation6 = Quaternion.AngleAxis(angle6, Vector3.up);

        int random=1;

        if(random == 1) {
            if (Vector3.Distance(target1.transform.position, transform.position) > slowDistance)
            {
                move(rotation1);

                if (Vector3.Distance(target1.transform.position, transform.position) == slowDistance)
                {
                    random = Random.Range(1, 2);
                }

                if (Vector3.Distance(target1.transform.position, transform.position) < slowDistance)
                {

                    if (Vector3.Distance(target1.transform.position, transform.position) > stopDistance)
                    {
                        Seek(target1);   // calls to this function should be reduced
                        turnSpeed += turnAcceleration * Time.deltaTime;
                        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
                        movSpeed += acceleration * Time.deltaTime;
                        movSpeed = Mathf.Min(movSpeed, maxVelocity);
                        transform.rotation = Quaternion.Slerp(transform.rotation,
                                                              rotation1, Time.deltaTime * turnSpeed);
                        transform.position += transform.forward.normalized * movSpeed *
                                              Time.deltaTime;
                    }

                }
            }

        }
        if (random == 2)
        {
            if (Vector3.Distance(target2.transform.position, transform.position) > slowDistance)
            {
                move(rotation2);
                if (Vector3.Distance(target2.transform.position, transform.position) == slowDistance)
                {
                    random = Random.Range(1, 2);
                }

                if (Vector3.Distance(target2.transform.position, transform.position) < slowDistance)
                {

                    if (Vector3.Distance(target2.transform.position, transform.position) > stopDistance)
                    {
                        Seek(target2);   // calls to this function should be reduced
                        turnSpeed += turnAcceleration * Time.deltaTime;
                        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
                        movSpeed += acceleration * Time.deltaTime;
                        movSpeed = Mathf.Min(movSpeed, maxVelocity);
                        transform.rotation = Quaternion.Slerp(transform.rotation,
                                                              rotation2, Time.deltaTime * turnSpeed);
                        transform.position += transform.forward.normalized * movSpeed *
                                              Time.deltaTime;
                    }

                }
            }
        }
               
    }
    void move(Quaternion rotation)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation,
                                Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * movSpeed * Time.deltaTime;

        movSpeed += acceleration * Time.deltaTime;
    }

    void Seek(GameObject target)
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;
        Vector3 movement = direction.normalized * acceleration;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
