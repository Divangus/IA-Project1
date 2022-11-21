using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CloseToBench : StateMachineBehaviour
{

    public NavMeshAgent men;
    public Vector3[] benches = { new Vector3(-55, 0, -48), new Vector3(-2, 0, -48)};

    public float radius = 5f;
    public float offset = 3f;

    Blackboard blackboard;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        men = animator.gameObject.GetComponent<NavMeshAgent>();
        blackboard = animator.GetComponent<Blackboard>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Approching bench");
        men.destination = blackboard.selectedBench;
        blackboard.selectedBench.y = animator.gameObject.transform.position.y;
        Debug.Log(blackboard.selectedBench);
        Debug.Log(animator.gameObject.transform.position);
        if (animator.gameObject.transform.position == blackboard.selectedBench)
        {
            animator.SetInteger("State", 2);            
        }
    }
}
