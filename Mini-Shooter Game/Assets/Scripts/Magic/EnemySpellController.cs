using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Magic
{
    [RequireComponent(typeof(SpellCaster))]
    public class EnemySpellController : MonoBehaviour
    {
        public Spell spell;
        private SpellCaster _spellCaster;
        public Transform target;
        public float aimSpread = 0.5f;
        public bool isActive = true;

        private void Start()
        {
            _spellCaster = gameObject.GetComponent<SpellCaster>();
        }

        private void Update()
        {
            if (isActive)
            {
                RotateOrientationTowardsPlayer();
                
                spell.UpdateCooldown(_spellCaster);

                try
                {
                    spell.Cast(_spellCaster);
                }
                catch (SpellOnCooldownException e)
                {
                    // handle if on cooldown
                }
            }
        }

        private void RotateOrientationTowardsPlayer()
        {
            _spellCaster.aimOrientation.rotation = Quaternion.FromToRotation(Vector3.forward,
                target.position - _spellCaster.spellOrigin.position);

            float xSpread = Random.Range(-aimSpread, aimSpread);
            float ySpread = Random.Range(-aimSpread, aimSpread);
            Vector3 spreadVec = new Vector3(xSpread, ySpread);
            
            _spellCaster.aimOrientation.Rotate(spreadVec);

        }
    }
}