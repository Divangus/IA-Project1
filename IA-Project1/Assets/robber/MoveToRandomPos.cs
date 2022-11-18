using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Action("MyActions/MoveToRandomPosition")]
[Help("Move the agent to a random position.")]
public class MoveRandom : BasePrimitiveAction
{

    [InParam("me")]
    GameObject me;

    public float radius = 8f;
    public float offset = 10f;
    public NavMeshAgent agent;
    float f = 4.0f;
    Vector3 worldTarget;

    public override void OnStart()
    {
        
        agent = me.GetComponent<NavMeshAgent>();
        agent.isStopped = false;
    }

    public override TaskStatus OnUpdate()
    {
        
        f += Time.deltaTime;

        if(f > 4.0f)
        {
            // parameters: float radius, offset;
            Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
            localTarget += new Vector3(0, 0, offset);
            worldTarget = me.transform.TransformPoint(localTarget);
            worldTarget.y = 0f;
            agent.destination = worldTarget;

            f = 0.0f;
        }

        return TaskStatus.RUNNING;
    }
}