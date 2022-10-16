using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seek : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target1, target2;
    public float maxVelocity;
    public float slowDistance;
    public float stopDistance;

    public float turnSpeed = 3;
    public float turnAcceleration = 1;
    public float maxTurnSpeed = 5;
    public float movSpeed = 1;
    public float acceleration = 2;
    int choose = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Seek
        Vector3 direction1 = target1.transform.position - transform.position;
        direction1.y = 0f;    // (x, z): position in the floor

        Vector3 direction2 = target2.transform.position - transform.position;
        direction2.y = 0f;    // (x, z): position in the floor

        Vector3 movement1 = direction1.normalized * maxVelocity;
        Vector3 movement2 = direction2.normalized * maxVelocity;

        float angle1 = Mathf.Rad2Deg * Mathf.Atan2(movement1.x, movement1.z);
        float angle2 = Mathf.Rad2Deg * Mathf.Atan2(movement2.x, movement2.z);

        Quaternion rotation1 = Quaternion.AngleAxis(angle1, Vector3.up);
        Quaternion rotation2 = Quaternion.AngleAxis(angle2, Vector3.up);



        if (Vector3.Distance(target1.transform.position, transform.position) > slowDistance && choose == 1)
        {
            move1();
            if (Vector3.Distance(target1.transform.position, transform.position) < slowDistance)
            {
                choose = 2;
                move2();
            }

            if (Vector3.Distance(target1.transform.position, transform.position) == slowDistance)
            {
                Seek(target2);
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

        if (Vector3.Distance(target2.transform.position, transform.position) > slowDistance && choose == 2)
        {
            move2();
            if (Vector3.Distance(target2.transform.position, transform.position) < slowDistance)
            {
                choose = 1;
                move1();
            }


            if (Vector3.Distance(target2.transform.position, transform.position) == slowDistance)
            {
                Seek(target1);
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


        void move1()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation1,
                                    Time.deltaTime * turnSpeed);
            transform.position += transform.forward.normalized * movSpeed * Time.deltaTime;

            movSpeed += acceleration * Time.deltaTime;
        }

        void move2()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation2,
                                    Time.deltaTime * turnSpeed);
            transform.position += transform.forward.normalized * movSpeed * Time.deltaTime;
            movSpeed += acceleration * Time.deltaTime;
        }
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