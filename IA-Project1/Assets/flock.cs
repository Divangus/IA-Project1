using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class flock : MonoBehaviour
{

    public FlockManager myManager;
    Vector3 direction;
    float speed = 2;
    float freq = 0f;
    public float freqA = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        freq += Time.deltaTime;
        if (freq > freqA)
        {
            freq -= freqA;
            direction = (Cohesion() + Align() + Separation() + (FollowLeader() * 5)).normalized * speed;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction), myManager.rotationSpeed * Time.deltaTime);
        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);

    }

    Vector3 Cohesion()
    {
        Vector3 cohesion = Vector3.zero;
        int num = 0;
        foreach (GameObject go in myManager.allPig)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    cohesion += go.transform.position;
                    num++;
                }
            }
        }
        if (num > 0)
        {
            return (cohesion / num - transform.position).normalized;
        }

        if (num == 0)
        {
            foreach (GameObject go in myManager.allPig)
            {
                if (go != this.gameObject)
                {
                    cohesion += go.transform.position;
                    num++;
                    
                }
            }
        }



        return (cohesion / num - transform.position).normalized;
    }

   Vector3 Align()
    {
        Vector3 align = Vector3.zero;
        int num = 0;
        foreach (GameObject go in myManager.allPig)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    align += go.GetComponent<flock>().direction;
                    num++;
                }
            }
        }
        if (num > 0)
        {
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.minSpeed, myManager.maxSpeed);
        }
        return align;
    }

    Vector3 Separation()
    {
        Vector3 separation = Vector3.zero;
        foreach (GameObject go in myManager.allPig)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                    separation -= (transform.position - go.transform.position) /
                                  (distance * distance);
            }
        }
        return separation;
    }

    Vector3 FollowLeader()
    {
       
        return (myManager.lider.transform.position - transform.position).normalized;
    }
}
