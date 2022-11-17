using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class steering : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, agent.transform.position) < agent.stoppingDistance) {
            return;
        }

        agent.destination = target.transform.position;
    } 
}
