using UnityEngine;
using UnityEngine.AI;

public class Caster : EnemyBase
{
    [SerializeField] public float backUpDistance;
    private NavMeshAgent _casterAI;
    public LayerMask isGround;
    private float _casterHeight;
    private bool _grounded;

    public Collider casterColl;
    
    protected override void EnemyAI()
    {
        _casterAI = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        EnemyAI();
        //casterColl = GetComponent<Collider>();
        chaseRange = initialChaseRange;
        health = 15.0f;
        backUpDistance = 3.0f;

        _casterHeight = 2.0f;
        _grounded = false;
    }
    
    void Update()
    {
        _grounded = Physics.Raycast(transform.position, Vector3.down, _casterHeight + 0.3f, isGround);
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        if (distanceToTarget <= chaseRange)
        {
            _casterAI.SetDestination(target.position);
            _casterAI.stoppingDistance = 15.0f; // Stops enemy short of player; casters only
            
            chaseRange = leashRange;
        }
        else
        {
            chaseRange = initialChaseRange;
        }

        if (distanceToTarget <= backUpDistance)
        {
            enemyAINavMeshAgent.Move(transform.position);
        }
        
        DestroyEnemy(casterColl, _grounded);
        
    }
    
    private void DestroyEnemy(Collider deadCaster, bool ground)
    {
        if (health == 0 && deadCaster.attachedRigidbody)
        {
            deadCaster.attachedRigidbody.useGravity = true;
            if (ground)
            {
                Destroy(_casterAI);
            }
        }
    }
}

