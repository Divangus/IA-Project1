using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Wandering : StateMachineBehaviour
{
    allscripts All;
    BlackBoard blackboard;

    public NavMeshAgent men;
    public GameObject bench;

    public float radius = 5f;
    public float offset = 3f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        All = animator.GetComponent<allscripts>();
        blackboard = animator.GetComponent<BlackBoard>();

        men = animator.gameObject.GetComponent<NavMeshAgent>();
        animator.SetBool("wander", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(men.transform.position, bench.transform.position) > 1f)
        {
            animator.SetBool("close", true);
            animator.SetBool("wander", false);
        }
        else
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
            localTarget += new Vector3(0, 0, offset);
            Vector3 worldTarget = men.transform.TransformPoint(localTarget);
            worldTarget.y = 0f;
            men.destination = worldTarget;

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}
}
