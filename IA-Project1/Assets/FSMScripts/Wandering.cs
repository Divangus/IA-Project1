using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : StateMachineBehaviour
{
    allscripts All;
    BlackBoard blackboard;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        All = animator.GetComponent<allscripts>();
        blackboard = animator.GetComponent<BlackBoard>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(blackboard.oldPerson.position, blackboard.bank.transform.position) > blackboard.dist2Sit)
            animator.SetTrigger("sit");
        else
            All.wander();
    }
}
