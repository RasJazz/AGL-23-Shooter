using Magic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemySpellController))]
public class Caster : EnemyBase
{
    [SerializeField] public float backUpDistance;
    private NavMeshAgent _casterAI;
    private EnemySpellController _spellController;

    [SerializeField] public GameObject casterEnemy;
    
    protected override void EnemyAI()
    {
        _casterAI = GetComponent<NavMeshAgent>();
        _spellController = GetComponent<EnemySpellController>();
    }
    void Start()
    {
        EnemyAI();
        health = 25.0f;
        chaseRange = initialChaseRange;
        name = "Caster";
    }
    
    void Update()
    {
        Vector3 casterPos = transform.position;
        Vector3 targetPos = target.position;
        Vector3 flatTargetPos = new Vector3(targetPos.x, casterPos.y, targetPos.z);
        
        distanceToTarget = Vector3.Distance(flatTargetPos, casterPos);
        
        if (distanceToTarget <= chaseRange)
        {
            _spellController.isActive = true; // spells are turned on
            if (distanceToTarget >= backUpDistance)
            {
                _casterAI.SetDestination(target.position);
                _casterAI.stoppingDistance = backUpDistance; // Stops enemy short of player; casters only
                
                chaseRange = leashRange;
            }
            else
            {
                Vector3 targetToCaster = casterPos - flatTargetPos;
                Debug.DrawLine(flatTargetPos, casterPos, Color.red);
                Vector3 backupPos = (targetToCaster.normalized * 10) + flatTargetPos;
                Debug.DrawLine(casterPos, backupPos, Color.green);
                _casterAI.SetDestination(backupPos);
                _casterAI.stoppingDistance = 0;
            }
        }
        else
        {
            _spellController.isActive = false; // spells stop firing and chase range is reset to init
            chaseRange = initialChaseRange;
        }
    }
}

