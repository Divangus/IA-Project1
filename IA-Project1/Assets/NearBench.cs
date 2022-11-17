using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NearBench : StateMachineBehaviour
{
    public NavMeshAgent men;
    public GameObject bench;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2f;

        men.SetDestination(bench.transform.position);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(men.transform.position, bench.transform.position) < 1f)
        {
            Debug.Log("Sit in the bank");
            animator.SetBool("sit", true);
        }
        else if (Vector3.Distance(men.transform.position, bench.transform.position) < 8f)
        {
            Debug.Log("Approching bench");
            animator.SetBool("close", true);
        };
    }
}
