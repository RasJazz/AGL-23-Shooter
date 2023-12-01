using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Magic.SpellTypes.Lightning
{
    [CreateAssetMenu(fileName = "New Lightning", menuName = "Lightning")]
    public class LightningSpell : Spell
    {
        [Header("Lightning")] public GameObject lightningSegment;
        public float damage;
        public float range;
        public float lifetime = 0.5f;

        public override void Cast(SpellCaster spellCaster)
        {
            base.Cast(spellCaster);
            HashSet<GameObject> hitEnemies = new HashSet<GameObject>();
            StrikeClosest(spellCaster.spellOrigin, hitEnemies);
        }

        private void StrikeClosest(Transform transform, HashSet<GameObject> hitEnemies)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
            var distanceOrder = hitColliders.OrderBy(obj => (obj.transform.position - transform.position).sqrMagnitude);
            foreach (Collider collider in distanceOrder)
            {
                Transform enemyTransform;
                if (collider.TryGetComponent(out Melee melee) && hitEnemies.Add(melee.gameObject))
                {
                    enemyTransform = melee.transform;
                }
                else if (collider.TryGetComponent(out Caster caster) && hitEnemies.Add(caster.gameObject))
                {
                    enemyTransform = caster.transform;
                }
                else continue;

                StrikeClosest(enemyTransform, hitEnemies);
                Vector3 from = transform.position;
                Vector3 to = enemyTransform.position;
                LightningPoints(from, to);
                Debug.DrawLine(from, to, Color.red, 500);
            }
        }

        private void LightningPoints(Vector3 point1, Vector3 point2)
        {
            GameObject segment = Instantiate(lightningSegment);
            Vector3 between = point2 - point1;
            float distance = between.magnitude;
            Transform transform = segment.transform;
            transform.localScale = new Vector3(0.1f, 0.1f, distance);
            transform.position = point1 + (between / 2.0f);
            transform.LookAt(point2);
            LightningSegment lightningSegmentComp = segment.AddComponent<LightningSegment>();
            lightningSegmentComp.LightningSpell = this;
        }
    }
}