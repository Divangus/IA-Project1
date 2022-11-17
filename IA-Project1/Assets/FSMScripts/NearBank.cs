using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Approaching : StateMachineBehaviour
{
    allscripts All;
    BlackBoard blackboard;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        All = animator.GetComponent<allscripts>();
        blackboard = animator.GetComponent<BlackBoard>();
        animator.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2f;
        All.Seek(blackboard.bank.transform.position);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(blackboard.bank.transform.position, animator.transform.position) < 2f)
        {
            blackboard.bank.GetComponent<Renderer>().enabled = false;
            Debug.Log("Sit in the bank");
            animator.SetTrigger("sit");
        }
        else
            if (Vector3.Distance(blackboard.oldPerson.position, blackboard.bank.transform.position) < blackboard.dist2Sit)
        {
            animator.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 1f;
            animator.SetTrigger("close");
        };
    }
}