using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fireball", menuName = "Fireball")]
public class FireballSpell : Spell
{
    [Header("Fireball")]
    public GameObject projectile;
    public float scale;
    
    public override void Cast(SpellCaster spellCaster)
    {
        base.Cast(spellCaster);
        Transform origin = spellCaster.transform;
        GameObject projectileObject = Instantiate(projectile, origin.position, origin.rotation);
        projectileObject.transform.localScale = new Vector3(scale, scale, scale);
        projectileObject.AddComponent<FireballProjectile>();
    }
}