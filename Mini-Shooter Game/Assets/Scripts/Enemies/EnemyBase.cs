using System;
using System.Collections;
using System.Collections.Generic;
using Magic;
using Magic.SpellTypes.Fireball;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    protected NavMeshAgent testAgent; // variable for accessing NavMeshAgent AI features
    protected float distanceToTarget = Mathf.Infinity; 
    
    [SerializeField] public Transform target; // player
    [SerializeField] public float chaseRange; // Sets distance that enemy will follow player
    [SerializeField] public float health;
    
    protected EnemyBase()
    {
        chaseRange = 0.0f;
        health = 0.0f;
    }
    
    protected EnemyBase(float chaseRange, float health)
    {
        this.chaseRange = chaseRange;
        this.health = health;
    }

    protected void EnemyAI()
    {
        testAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
        // testAgent.autoBraking = true; DIDN'T DO ANYTHING NOTICEABLE
    }
}
