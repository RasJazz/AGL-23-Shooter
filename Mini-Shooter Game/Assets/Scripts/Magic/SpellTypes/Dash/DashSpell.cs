using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dash", menuName = "Dash")]
public class DashSpell : Spell
{
    [Header("Dash")] 
    public float power;
    public float moveThreshold;

    public override void Cast(SpellCaster spellCaster)
    {
        Vector3 velocity = spellCaster.casterRigidbody.velocity;
        if (velocity.magnitude >= moveThreshold)
        {
            base.Cast(spellCaster);
            Vector3 moveDirection = velocity.normalized;
            spellCaster.casterRigidbody.transform.Translate(moveDirection * power);
        }

    }
}