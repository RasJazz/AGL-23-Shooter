using UnityEngine;

public class Melee : EnemyBase
{
    void Start()
    {
        EnemyAI();
        chaseRange = initialChaseRange;
        health = 30.0f;
        name = "Melee";
    }
    
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        // If player is w/i x units of enemy, enemy engages player
        if (distanceToTarget <= chaseRange)
        {
            enemyAINavMeshAgent.SetDestination(target.position);
            chaseRange = leashRange;
        }
        else // when player out of range of enemy, its chaseRange is reset
        {
            chaseRange = initialChaseRange;
        }
    }

}
