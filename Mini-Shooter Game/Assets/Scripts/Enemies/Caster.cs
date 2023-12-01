using Magic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemySpellController))]
public class Caster : EnemyBase
{
    [SerializeField] public float backUpDistance;
    private NavMeshAgent _casterAI;
    private EnemySpellController _spellController;
    public LayerMask isGround;
    private float _casterHeight;
    private bool _grounded;

    public Collider casterColl;
    
    protected override void EnemyAI()
    {
        _casterAI = GetComponent<NavMeshAgent>();
        _spellController = GetComponent<EnemySpellController>();
    }
    void Start()
    {
        EnemyAI();
        //casterColl = GetComponent<Collider>();
        chaseRange = initialChaseRange;

        _casterHeight = 2.0f;
        _grounded = false;
    }
    
    void Update()
    {
        Vector3 casterPos = transform.position;
        
        _grounded = Physics.Raycast(casterPos, Vector3.down, _casterHeight + 0.3f, isGround);
        
        Vector3 targetPos = target.position;
        Vector3 flatTargetPos = new Vector3(targetPos.x, casterPos.y, targetPos.z);
        
        distanceToTarget = Vector3.Distance(flatTargetPos, casterPos);
        
        if (distanceToTarget <= chaseRange)
        {
            _spellController.isActive = true;
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
            _spellController.isActive = false;
            chaseRange = initialChaseRange;
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

