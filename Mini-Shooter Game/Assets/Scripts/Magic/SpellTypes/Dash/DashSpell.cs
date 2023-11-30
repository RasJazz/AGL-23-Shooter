using UnityEngine;

namespace Magic.SpellTypes.Dash
{
    [CreateAssetMenu(fileName = "New Dash", menuName = "Dash")]
    public class DashSpell : Spell
    {
        [Header("Dash")] 
        public float power;
        public float moveThreshold;

        public override void Cast(SpellCaster spellCaster)
        {
            Vector3 velocity = spellCaster.casterRigidbody.velocity;
            Vector3 dashVelocity = new Vector3(velocity.x, 0, velocity.z);
            
            if (dashVelocity.magnitude >= moveThreshold)
            {
                if (spellCaster.TryGetComponent(out PlayerMovement playerMovement) && !playerMovement.grounded) 
                    return;
                
                base.Cast(spellCaster);
                Vector3 moveDirection = dashVelocity.normalized;
                
                spellCaster.casterRigidbody.AddForce(moveDirection * (power * 10), ForceMode.Impulse);
            }

        }
    }
}