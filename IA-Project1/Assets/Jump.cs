using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public GameObject target1, target2;
    public float maxVelocity = 6;
    public float slowDistance = 4;
    public float stopDistance = 2;

    public float turnSpeed = 7;
    public float turnAcceleration = 2;
    public float maxTurnSpeed = 7;
    public float movSpeed = 5;
    public float acceleration = 2;
    int choose = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction1 = target1.transform.position - transform.position;
        direction1.x = 0f;
        direction1.z = 0f;
        Vector3 direction2 = target2.transform.position - transform.position;
        direction2.x = 0f;
        direction2.z = 0f;


        Vector3 movement1 = direction1.normalized * maxVelocity;
        Vector3 movement2 = direction2.normalized * maxVelocity;


        float angle1 = Mathf.Rad2Deg * Mathf.Atan(movement1.y);
        float angle2 = Mathf.Rad2Deg * Mathf.Atan(movement2.y);

        Quaternion rotation1 = Quaternion.AngleAxis(angle1, Vector3.up);
        Quaternion rotation2 = Quaternion.AngleAxis(angle2, Vector3.up);

        if (Vector3.Distance(target1.transform.position, transform.position) > slowDistance && choose==1)
        {
            move(rotation1);
            if (Vector3.Distance(target1.transform.position, transform.position) < slowDistance)
            {
                choose = 2;
                move(rotation2);
            }
        }
        if (Vector3.Distance(target2.transform.position, transform.position) > slowDistance && choose==2)
        {
            move(rotation2);
            if (Vector3.Distance(target2.transform.position, transform.position) < slowDistance)
            {
                choose = 1;
                move(rotation1);
            }
        }




        void move(Quaternion rotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation,
              Time.deltaTime * turnSpeed);
            transform.position += transform.forward.normalized * movSpeed * Time.deltaTime;

            movSpeed += acceleration * Time.deltaTime;
        }



    }
}
