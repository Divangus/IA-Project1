using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class allscripts : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    public float radius, offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void wander()
    {
        Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
        localTarget += new Vector3(0, 0, offset);
        Vector3 worldTarget = transform.TransformPoint(localTarget);
        worldTarget.y = 0f;
    }

    //void Seek(Vector3 location)
    //{
    //    agent = SetDestination(location);
    //}

    //private NavMeshAgent SetDestination(Vector3 location)
    //{

    //    return ;
    //}
}
