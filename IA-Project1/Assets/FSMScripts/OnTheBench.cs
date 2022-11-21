using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnTheBench : StateMachineBehaviour
{
    public NavMeshAgent men;

    public Vector3[] benches = { new Vector3(-55, 0, -48), new Vector3(-2, 0, -48)};
    float duration = 0.0f;
    bool a = false;

    public float radius = 5f;
    public float offset = 3f;

    Blackboard blackboard;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        men = animator.gameObject.GetComponent<NavMeshAgent>();
        a = false;
        blackboard = animator.GetComponent<Blackboard>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        duration += Time.deltaTime;
        if (duration > 5.0f)
        {
            Debug.Log("Not Sitting");
           
            for(int i =0; i < benches.Length; i++)
            {
                if (blackboard.selectedBench == benches[i])
                {
                    blackboard.someone[i] = false;
                }
                //blackboard.flag[i] = false;
            }
            a = true;
        }

        if (a == true)
        {
            animator.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2f;
            //Debug.Log("Making Wander");
            Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
            localTarget += new Vector3(0, 0, offset);
            Vector3 worldTarget = men.transform.TransformPoint(localTarget);
            worldTarget.y = 0f;
            men.destination = worldTarget;

            if (Vector3.Distance(animator.gameObject.transform.position, blackboard.selectedBench) > 23f)
            {
                animator.SetInteger("State", 0);
            }
        }

    }
}

