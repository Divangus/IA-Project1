using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Wandering : StateMachineBehaviour
{
    public NavMeshAgent men;
    //public GameObject bench;

    public Vector3[] benches = { new Vector3(-55,0,-48)};

    public float radius = 5f;
    public float offset = 3f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        men = animator.gameObject.GetComponent<NavMeshAgent>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(Vector3.Distance(animator.gameObject.transform.position, benches[0]));
        if (Vector3.Distance(animator.gameObject.transform.position, benches[0]) < 15f)
        {
            Debug.Log("Changing State");
            animator.SetInteger("State", 1);
        }
        else 
        {
            animator.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 4f;
            Debug.Log("Making Wander");
            Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
            localTarget += new Vector3(0, 0, offset);
            Vector3 worldTarget = men.transform.TransformPoint(localTarget);
            worldTarget.y = 0f;
            men.destination = worldTarget;

        }
    }

    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        
    //}
}
