using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Magic.SpellTypes.Fireball
{
    [CreateAssetMenu(fileName = "New Fireball", menuName = "Fireball")]
    public class FireballSpell : Spell
    {
        [Header("Fireball")]
        public GameObject projectile;
        [FormerlySerializedAs("power")] public float speed;
        public String[] ignoreTags;
        public float damage;
        public float scale;
    
        public override void Cast(SpellCaster spellCaster)
        {
            base.Cast(spellCaster);
            spellCaster.OrientationOrRaycast(out Vector3 position, out Quaternion rotation);
            GameObject projectileObject = Instantiate(projectile, position, rotation);
            projectileObject.transform.localScale = new Vector3(scale, scale, scale);
            FireballProjectile fireballProjectile = projectileObject.AddComponent<FireballProjectile>();
            fireballProjectile.FireballSpell = this;
        }
    }
}