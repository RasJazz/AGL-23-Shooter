using System;
using System.Collections;
using System.Collections.Generic;
using Magic;
using Magic.SpellTypes.Fireball;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    protected NavMeshAgent enemyAINavMeshAgent; // variable for accessing NavMeshAgent AI features
    protected float distanceToTarget = Mathf.Infinity;
    
    [SerializeField] public Transform target; // player 
    [SerializeField] public float initialChaseRange;// Sets distance that enemy will follow player
    protected float chaseRange; // temp variable to hold initChaseRange, resets when player leashes enemy
    [SerializeField] public float leashRange; // distance enemy will aggro player until player escapes
    [SerializeField] public float health;
    
    protected EnemyBase()
    {
        
        initialChaseRange = 15.0f;
        chaseRange = 0.0f;
        leashRange = 20.0f;
        health = 0.0f;
    }
    
    protected EnemyBase(float chaseRange, float leashRange, float health)
    {
        this.chaseRange = chaseRange;
        this.leashRange = leashRange;
        this.health = health;
    }

    protected virtual void EnemyAI()
    {
        enemyAINavMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
