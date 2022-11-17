using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NearBench : StateMachineBehaviour
{
    public NavMeshAgent men;
    public GameObject bench;

    public Vector3[] benches = { new Vector3(-57, 0, -41) };

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2f;

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(animator.gameObject.transform.position, benches[0]) < 0.4f)
        {
            Debug.Log("Sit in the bank");
            animator.SetInteger("State", 2);
        }
        else
        {
            animator.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2f;
            Debug.Log("Approching bench");
            animator.SetInteger("State", 1);
            men.SetDestination(benches[0]);
        }
    }
}
