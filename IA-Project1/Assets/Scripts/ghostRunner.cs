using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class ghostRunner : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] checkPoints;
    int choose = 0;
    public NavMeshAgent agent;
    public string Tag;
    void Start()
    {
        checkPoints = GameObject.FindGameObjectsWithTag(Tag);
    }

    // Update is called once per frame
    void Update()
    {
        Seek(checkPoints[choose]);

        if (Vector3.Distance(checkPoints[choose].transform.position, agent.transform.position) < agent.stoppingDistance)
        {
            choose += 1;

            if (choose >= checkPoints.Length)
            {
                choose = 0;
            }
        }
    }


    void Seek(GameObject target)
    {
        agent.destination = target.transform.position;
    }
}