using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Action("MyActions/MoveToRandomPosition")]
[Help("Move the agent to a random position.")]
public class MoveRandom : BasePrimitiveAction
{
    public float radius = 5f;
    public float offset = 3f;
    public NavMeshAgent agent;
    float f = 0.0f;
    GameObject robber;
    Vector3 worldTarget;

    public override void OnStart()
    {
        robber = GameObject.Find("Robber (1)");
        agent = robber.GetComponent<NavMeshAgent>();
        agent.isStopped = false;
    }

    public override TaskStatus OnUpdate()
    {
        
        f += Time.deltaTime;

        if(f > 5.0f)
        {
            // parameters: float radius, offset;
            Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
            localTarget += new Vector3(0, 0, offset);
            worldTarget = robber.transform.TransformPoint(localTarget);
            worldTarget.y = 0f;
            agent.destination = worldTarget;

            f = 0.0f;
        }

        

        return TaskStatus.RUNNING;
    }
}