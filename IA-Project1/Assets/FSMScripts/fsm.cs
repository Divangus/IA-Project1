using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fsm : MonoBehaviour
{
  
    private WaitForSeconds wait = new WaitForSeconds(0.05f);   // 1 / 20
    delegate IEnumerator State();
    private State state;
    IEnumerator Start()
    {
        state = Wander;
        while (enabled)
            yield return StartCoroutine(state());
    }
    IEnumerator Wander()
    {
        Debug.Log("Wander state");
        yield return new wander();

    }
}
