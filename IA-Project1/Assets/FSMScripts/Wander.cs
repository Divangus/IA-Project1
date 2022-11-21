using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Wander : StateMachineBehaviour
{
    public NavMeshAgent men;
    public Vector3[] benches = { new Vector3(-55, 0, -48), new Vector3(-2, 0, -48.6f) };

    public Vector3 selectedBench;
    public float radius = 5f;
    public float offset = 3f;

    Blackboard blackboard;

    bool flag = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        men = animator.gameObject.GetComponent<NavMeshAgent>();
        blackboard = animator.GetComponent<Blackboard>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log(Vector3.Distance(animator.gameObject.transform.position, benches[0]));
        for (int i = 0; i < benches.Length; i++)
        {
            if (Vector3.Distance(animator.gameObject.transform.position, benches[i]) < 15f)
            {
                flag = true;
                blackboard.selectedBench = benches[i];
                //selectedBench = benches[i];
                Debug.Log("Changing State");
                animator.SetInteger("State", 1);
            }
        }
        if (flag != true)
        {
            Debug.Log("Making Wander");
            Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
            localTarget += new Vector3(0, 0, offset);
            Vector3 worldTarget = men.transform.TransformPoint(localTarget);
            worldTarget.y = 0f;
            men.destination = worldTarget;
        }

    }
}
