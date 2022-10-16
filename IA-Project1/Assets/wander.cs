using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wander : MonoBehaviour {
    public float Radius;
    public float offset;
    public GameObject agent;
    public Vector3 movement;


    // Use this for initialization
    void Start() {
       
    }
    // Update is called once per frane
    void Update() {

        Radius = 5;
        Vector3 direction = UnityEngine.Random.insideUnitCircle.normalized;

        Vector3 toTarget = agent.transform.position - transform.position;
        if (Vector3.Dot(toTarget, direction) > 0f)
        {
            direction = Vector3.Reflect(direction, toTarget);
        }

        Vector3 finalPosition = agent.transform.position + direction * Radius;
   

        Vector2 fromTarget = (transform.position - transform.position).normalized;
        Vector2 perpendicular = new Vector2(-fromTarget.y, fromTarget.x);

        float angle = UnityEngine.Random.Range(0, Mathf.PI);

        Vector2 offset = fromTarget * Mathf.Sin(angle) + perpendicular * Mathf.Cos(angle);

        Vector3 a = agent.transform.position + (Vector3)(offset * Radius);
    }
 
}