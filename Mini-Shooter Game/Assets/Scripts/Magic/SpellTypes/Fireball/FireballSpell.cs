using UnityEngine;

namespace Magic.SpellTypes.Fireball
{
    [CreateAssetMenu(fileName = "New Fireball", menuName = "Fireball")]
    public class FireballSpell : Spell
    {
        [Header("Fireball")]
        public GameObject projectile;
        public float power;
    
        public override void Cast(SpellCaster spellCaster)
        {
            base.Cast(spellCaster);
            GameObject projectileObject = Instantiate(projectile, spellCaster.spellOrigin.transform.position, spellCaster.aimOrientation.rotation);
            projectileObject.transform.localScale = new Vector3(power, power, power);
            FireballProjectile fireballProjectile = projectileObject.AddComponent<FireballProjectile>();
            fireballProjectile.FireballSpell = this;
        }
    }
}