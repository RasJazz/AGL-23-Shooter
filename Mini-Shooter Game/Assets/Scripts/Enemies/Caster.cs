using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : EnemyBase
{
    void Start()
    {
        EnemyAI();
        health = 10.0f;
    }
    
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= chaseRange)
        {
            testAgent.SetDestination(target.position);
        }
        testAgent.stoppingDistance = 10.0f; // Stops enemy short of player
    }
}
