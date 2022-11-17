using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour
{
    public Transform men;
    public GameObject bench;
    public float dist2Steal = 10f;
    allscripts All;
    UnityEngine.AI.NavMeshAgent agent;

    private WaitForSeconds wait = new WaitForSeconds(0.05f); // == 1/20
    delegate IEnumerator State();
    private State state;

    IEnumerator Start()
    {
        All = gameObject.GetComponent<allscripts>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

        yield return wait;

        state = Wander;

        while (enabled)
            yield return StartCoroutine(state());
    }

    IEnumerator Wander()
    {
        Debug.Log("Wander state");

        while (Vector3.Distance(men.position, bench.transform.position) < dist2Steal)
        {
            All.wander();
            yield return wait;
        };

        state = Approaching;
    }

    IEnumerator Approaching()
    {
        Debug.Log("Approaching state");

        agent.speed = 2f;
        All.Seek(bench.transform.position);

        bool stolen = false;
        while (Vector3.Distance(men.position, bench.transform.position) > dist2Steal)
        {
            if (Vector3.Distance(bench.transform.position, transform.position) < 2f)
            {
                stolen = true;
                break;
            };
            yield return wait;
        };

        if (stolen)
        {
            bench.GetComponent<Renderer>().enabled = false;
            Debug.Log("Stolen");
            state = Hiding;
        }
        else
        {
            agent.speed = 1f;
            state = Wander;
        }
    }


    IEnumerator Hiding()
    {
        Debug.Log("Hiding state");

        while (true)
        {
            //All.Hide();
            yield return wait;
        };
    }
}